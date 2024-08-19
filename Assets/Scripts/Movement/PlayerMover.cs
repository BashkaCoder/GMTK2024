using BananaForScale.Attributes;
using UnityEngine;

namespace BananaForScale.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Health))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidBody;
        private Health _health;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            if (_health.IsDead) return;
            Move();
        }

        private void Move()
        {
            var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _rigidBody.MovePosition(_rigidBody.position + _speed * Time.deltaTime * movement.normalized);
        }
    }
}
