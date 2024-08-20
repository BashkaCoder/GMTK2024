using BananaForScale.Attributes;
using UnityEngine;

namespace BananaForScale.Movement
{
    [RequireComponent(typeof(Health))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        private Rigidbody _rigidbody;
        private Health _health;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private AudioSource _moveSound;
        [SerializeField] private float _soundDelay = 0.2f;

        public Vector3 Direction => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        private bool IsStopped => Direction != Vector3.zero;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            if (_health.IsDead) return;
            Move(_speed * Time.deltaTime * Direction);
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction);
            RotateSprite();
            PlayMoveSound();
        }

        private void RotateSprite()
        {
            var horisontal = Input.GetAxis("Horizontal");
            if (horisontal != 0 && horisontal < 0)
            {
                _sprite.flipX = true;
            }
            else if (horisontal != 0 && horisontal > 0)
            {
                _sprite.flipX = false;
            }
        }

        private void PlayMoveSound()
        {
            if (IsStopped && !_moveSound.isPlaying)
            {
                _moveSound.PlayDelayed(_soundDelay);
            }
        }
    }
}
