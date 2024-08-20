using UnityEngine;

namespace BananaForScale
{
    public enum LocationType
    {
        Hub,
        Dungeon,
        Boss
    }

    public class AmbientChanger : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _audioClips;
        private AudioSource _audioSource;

        public static AmbientChanger Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public void ChangeAmbientLocation(LocationType locationType)
        {
            PlayAmbient(_audioClips[(int)locationType]);
        }

        private void PlayAmbient(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                ChangeAmbientLocation(LocationType.Hub);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                ChangeAmbientLocation(LocationType.Dungeon);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                ChangeAmbientLocation(LocationType.Boss);
            }
        }
    }
}