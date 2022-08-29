using UnityEngine;
using UnityEngine.SceneManagement;
using DeathLight.GlobalHandlers;

namespace DeathLight.UI
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private int mainMenuBInddex;

        private SoundManager soundManager;
        private bool isPaused;
        private void Start()
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            Time.timeScale = 1f;
            soundManager = SoundManager.Instance;
        }

        private void Update()
        {
            if (isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                OnResumeClicked();
            }
            else if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseClicked();
            }
        }

        public void GameOver()
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        public void OnRetryClicked()
        {
            if (soundManager)
            {
                soundManager.ResetSounds();
            }
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnMainMenuClicked()
        {
            SceneManager.LoadScene(mainMenuBInddex);
        }
        public void OnPauseClicked()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            if(soundManager)
            {
                soundManager.StopMusic();
            }
        }
        public void OnResumeClicked()
        {
            if(soundManager)
            {
                soundManager.ResetSounds();
            }
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        public void OnButtonClick()
        {
            if (soundManager)
            {
                soundManager.PlaySfx(Sounds.ButtonClick);
            }
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}
