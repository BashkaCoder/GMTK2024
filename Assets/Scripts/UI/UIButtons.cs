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
            _quitButton.gameObject.SetActive(Application.platform != RuntimePlatform.WebGLPlayer);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
