using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BananaForScale.UI
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] private Button _quitButton;

        private void Start()
        {
            if (_quitButton) _quitButton.gameObject.SetActive(Application.platform != RuntimePlatform.WebGLPlayer);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }
    }
}
