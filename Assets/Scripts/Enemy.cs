using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject target;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        InvokeRepeating("FindClosestTarget", 0f, 1f); // Call the FindClosestTarget function for the nearest enemy
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 lookDirection = (target.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

        if (transform.position.y < -10)
        {
          
            Destroy(gameObject);
        }
    }
    // Find nearest target
    void FindClosestTarget()
    {
        Debug.Log("close target");
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        targets = CombineArrays(targets, GameObject.FindGameObjectsWithTag("Player"));

        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;
        Vector3 currentPosition = transform.position;

        foreach (GameObject targetObject in targets)
        {
            if (targetObject != gameObject)
            {
                float distanceToTarget = Vector3.Distance(currentPosition, targetObject.transform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestTarget = targetObject;
                }
            }
        }

        target = closestTarget;
    }

    GameObject[] CombineArrays(GameObject[] arr1, GameObject[] arr2)
    {
        GameObject[] combinedArray = new GameObject[arr1.Length + arr2.Length];
        arr1.CopyTo(combinedArray, 0);
        arr2.CopyTo(combinedArray, arr1.Length);
        return combinedArray;
    }
}
