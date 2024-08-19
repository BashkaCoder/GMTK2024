using UnityEngine;
using UnityEngine.Events;

namespace BananaForScale.Attributes
{
    public class Satiety : MonoBehaviour
    {
        [SerializeField] private float _maxSatietyPoints;
        [SerializeField] private UnityEvent _onFeed;
        private float _satietyPoints = 0;

        public float SatietyPoints => _satietyPoints;
        public float MaxSatietyPoints => _maxSatietyPoints;
        public bool IsHungry { get; set; } = true;

        public void Feed(float foodValue)
        {
            _satietyPoints = Mathf.Min(_satietyPoints + foodValue, MaxSatietyPoints);
            _onFeed.Invoke();
            IsHungry = SatietyPoints != MaxSatietyPoints;
            print($"I EAT {foodValue}");
        }
    }
}
