using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Sumo");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
