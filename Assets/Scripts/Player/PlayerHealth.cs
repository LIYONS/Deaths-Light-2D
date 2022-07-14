using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject[] life;
    [SerializeField] Menu menu;
    int livesCount;
    SoundManager soundManager;

    Vector3 startPos;
    private void Start()
    {
        livesCount = life.Length;
        startPos = transform.position;
        soundManager = SoundManager.instance;
    }
    private void Update()
    {
        if(transform.position.y<startPos.x-20)
        {
            Kill();
        }
    }
    public void DeleteLife()
    {
        if(livesCount==0f)
        {
            Kill();
        }
        else
        {
            life[--livesCount].SetActive(false);
            soundManager.PlaySfx(Sounds.Hurt);
        }
    }
     void Kill()
    {
        menu.GameOver();
        gameObject.SetActive(false);
        soundManager.StopMusic();
    }
}
