using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSingleton : MonoBehaviour
{

    private static GameManagerSingleton _instance;

    public static GameManagerSingleton instance { get { return _instance; } }


    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    bool isPaused;

    private void Awake()
    {
        if(_instance)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
        else if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadSelectedScene(int buildIndexNo)
    {
        SceneManager.LoadScene(buildIndexNo);
    }
}
