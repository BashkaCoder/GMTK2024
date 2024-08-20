using BananaForScale.Combat;
using BananaForScale.Movement;
using UnityEngine;

namespace BananaForScale.UI
{
    public class HowToPlayScreen : MonoBehaviour
    {
        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            SwitchPlayer(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.SetActive(false);
                SwitchPlayer(true);
            }
        }

        private void SwitchPlayer(bool enabled)
        {
            _player.GetComponent<PlayerMover>().enabled = enabled;
            _player.GetComponent<Fighter>().enabled = enabled;
        }
    }
}
