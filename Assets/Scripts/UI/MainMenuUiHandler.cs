using UnityEngine;
using UnityEngine.SceneManagement;
using DeathLight.GlobalHandlers;

namespace DeathLight.UI
{
    public class MainMenuUiHandler : MonoBehaviour
    {
        [SerializeField] private int firstSceneBIndex;

        private SoundManager soundManager;

        private void Start()
        {
            soundManager = SoundManager.Instance;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Quit();
            }
        }
        public void OnButtonClick()
        {
            if (soundManager)
            {
                soundManager.PlaySfx(Sounds.ButtonClick);
            }
        }
        public void StartGame()
        {
            SceneManager.LoadScene(firstSceneBIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
