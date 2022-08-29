using UnityEngine;
using UnityEngine.SceneManagement;
using DeathLight.GlobalHandlers;

namespace DeathLight.Player
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private int winBuildIndex;

        private SoundManager soundManager;
        private void Start()
        {
            soundManager = SoundManager.Instance;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerMovement>())
            {
                if (soundManager)
                {
                    soundManager.PlaySfx(Sounds.Win);
                }
                SceneManager.LoadScene(winBuildIndex);
            }
        }
    }
}
