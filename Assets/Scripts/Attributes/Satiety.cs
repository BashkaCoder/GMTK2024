using UnityEngine;
using UnityEngine.Events;

namespace BananaForScale.Attributes
{
    public class Satiety : MonoBehaviour
    {
        [SerializeField] private float _maxSatietyPoints;
        [SerializeField] private UnityEvent<float> _onFeed;
        [SerializeField] private EnemyType _enemyType;
        private float _satietyPoints = 0;
        [SerializeField] private Transform _sprite;
        private Vector3 _startLocalScale;

        private void Awake()
        {
            _startLocalScale = _sprite.localScale;
        }

        private float GrowthMultiplier => 1 + SatietyPoints / MaxSatietyPoints;

        public float SatietyPoints => _satietyPoints;
        public float MaxSatietyPoints => _maxSatietyPoints;
        public EnemyType Type => _enemyType;
        public bool IsHungry { get; set; } = true;

        public void Feed(float foodValue)
        {
            _satietyPoints = Mathf.Min(_satietyPoints + foodValue, MaxSatietyPoints);
            _onFeed.Invoke(GrowthMultiplier);
            IncreaseSpriteSize();

            if (SatietyPoints == MaxSatietyPoints)
            {
                IsHungry = false;
                EnemyZoneManager.IncreaseFullFeedEnemyCount(_enemyType);
            }
            print($"I EAT {foodValue}");
        }

        private void IncreaseSpriteSize()
        {
            Vector3 newScale = _startLocalScale * GrowthMultiplier;
            _sprite.localScale = newScale;
        }
    }
}
