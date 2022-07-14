using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    SoundManager soundManager;
    private void Start()
    {
        soundManager = SoundManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            soundManager.PlaySfx(Sounds.Win);
            SceneManager.LoadScene(2);
        }
    }
}
