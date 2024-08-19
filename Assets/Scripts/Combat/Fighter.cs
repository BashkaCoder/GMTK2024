using UnityEngine;

namespace BananaForScale.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenAttacks = 1f;
        private float _timeSinceLastAttack = Mathf.Infinity;
        private Animator _animator;
        [SerializeField] private float _foodValue = 10f;
        [SerializeField] private Projectile _projectilePrefab;
        private Vector3 _direction;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;

            if (Input.GetMouseButton(0)) AttackBehaviour();
        }

        private void AttackBehaviour()
        {
            if (_timeSinceLastAttack > _timeBetweenAttacks)
            {
                Shoot();
                _timeSinceLastAttack = 0;
            }
        }

        private void Shoot()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var direction = hit.point - transform.position;
                direction.y = transform.position.y;

                Debug.DrawRay(transform.position, direction, Color.red);

                LaunchProjecttile(direction, _foodValue);
            }
        }

        private void LaunchProjecttile(Vector3 direction, float foodValue)
        {
            var spawnPosition = transform.position + direction.normalized;
            spawnPosition.y = transform.position.y;

            var projectileInstance = Instantiate(_projectilePrefab,
                spawnPosition, Quaternion.identity);
            projectileInstance.SetTarget(transform.position + direction * 2, foodValue);
        }

        private static Ray GetMouseRay() => Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
