using UnityEngine;
using DeathLight.GlobalHandlers;
using DeathLight.UI;
using System.Collections.Generic;

namespace DeathLight.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private List<GameObject> life;
        [SerializeField] private UIHandler uiHandler;
        [SerializeField] private GameObject damagePS;

        private SoundManager soundManager;
        private void Start()
        {
            soundManager = SoundManager.Instance;
        }
        public void TakeDamage()
        {
            Instantiate(damagePS, transform.position, Quaternion.identity);
            life[^1].SetActive(false);
            if (life.Count<=1)
            {
                Death();
            }
            else
            {
                _ = life.Remove(life[^1]);
                if (soundManager)
                {
                    soundManager.PlaySfx(Sounds.Hurt);
                }
            }
        }
        public void Death()
        {
            uiHandler.GameOver();
            gameObject.SetActive(false);
            if (soundManager)
            {
                soundManager.StopMusic();
            }
        }
    }
}
