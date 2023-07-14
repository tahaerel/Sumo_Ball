using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI scoreText, timertext;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    private float counter_time = 60f;
    private float passing_time = 0f;
    int remaining_time;
    public static bool GameIsPaused = false;
    void Start()
    {
        score = 0;
        deathMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(Countdown());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        scoreText.text = "Score: " + score;        
    }
    
    // Score and death
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("player collider");

            DeathMenu();
        }

        if(other.gameObject.tag == "Enemy")
        {
            score+= 10;
            Debug.Log("Score = " + score);
        }
        
    }

    //Coutdown
    IEnumerator Countdown()
    {
        while (passing_time < counter_time)
        {
            passing_time += Time.deltaTime;

            remaining_time = (int)(counter_time - passing_time);
            timertext.text = remaining_time.ToString();

            yield return null;
        }

        DeathMenu();
    }




    // Menu Functions

    public void DeathMenu()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Reset()
    {
        SceneManager.LoadScene("Sumo");
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
