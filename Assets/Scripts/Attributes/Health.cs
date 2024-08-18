using UnityEngine;
using UnityEngine.Events;

namespace BananaForScale.Attributes
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> _onTakeDamage;
        [SerializeField] private UnityEvent<float> _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private float _maxHealthPoints;

        public float HealthPoints { get; private set; }
        public float MaxHealthPoints => _maxHealthPoints;
        public bool IsDead { get; private set; }

        private void Awake()
        {
            HealthPoints = MaxHealthPoints;
        }

        public void TakeDamage(float damage)
        {
            HealthPoints = Mathf.Max(HealthPoints - damage, 0);
            if (HealthPoints == 0)
            {
                _onDie.Invoke();
                Die();
            }
            else
            {
                _onTakeDamage.Invoke(-damage);
            }
        }

        private void Update()
        {
            print($"Health {HealthPoints}");
        }
        private void Die()
        {
            if (IsDead) return;

            IsDead = true;
            // TODO
            //const string TriggerName = "Die";
            //GetComponent<Animator>().SetTrigger(TriggerName);
        }

        public void Heal(float healthToRestore)
        {
            HealthPoints = Mathf.Min(HealthPoints + healthToRestore, MaxHealthPoints);
            _onHeal.Invoke(healthToRestore);
        }
    }
}
