using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    SoundManager soundManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    bool isPaused;
    private void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        soundManager = SoundManager.instance;
    }

    private void Update()
    {
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
        else if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
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
        soundManager.PlaySfx(Sounds.ButtonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        soundManager.PlaySfx(Sounds.ButtonClick);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        soundManager.PlaySfx(Sounds.ButtonClick);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Quit()
    {
        soundManager.PlaySfx(Sounds.ButtonClick);
        Application.Quit();
    }
}
