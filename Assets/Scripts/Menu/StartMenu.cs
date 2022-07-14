using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
    public void StartGame()
    {
        soundManager.PlaySfx(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        soundManager.PlaySfx(Sounds.ButtonClick);
        Application.Quit();
    }
}
