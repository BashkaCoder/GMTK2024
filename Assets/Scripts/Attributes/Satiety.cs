using UnityEngine;
using UnityEngine.Events;

namespace BananaForScale.Attributes
{
    public class Satiety : MonoBehaviour
    {
        [SerializeField] private float _maxSatietyPoints;
        [SerializeField] private UnityEvent _onFeed;
        [SerializeField] private EnemyType _enemyType;
        private float _satietyPoints = 0;

        public float SatietyPoints => _satietyPoints;
        public float MaxSatietyPoints => _maxSatietyPoints;
        public EnemyType Type => _enemyType;
        public bool IsHungry { get; set; } = true;

        public void Feed(float foodValue)
        {
            _satietyPoints = Mathf.Min(_satietyPoints + foodValue, MaxSatietyPoints);
            _onFeed.Invoke();

            if (SatietyPoints == MaxSatietyPoints)
            {
                IsHungry = false;
                EnemyZoneManager.IncreaseFullFeedEnemyCount(_enemyType);
            }
            print($"I EAT {foodValue}");
        }
    }
}
