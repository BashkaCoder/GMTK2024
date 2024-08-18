using BananaForScale.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BananaForScale.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _fill;
        [SerializeField] private TMP_Text _healthText;

        private void Start()
        {
            UpdateBar();
        }

        public void UpdateBar()
        {
            SetBarText((int)_health.HealthPoints, (int)_health.MaxHealthPoints);
            SetBarImageFill(_health.HealthPoints / _health.MaxHealthPoints);
        }

        private void SetBarText(float currentValue, float maxValue)
        {
            _healthText.text = $"{currentValue} / {maxValue}";
        }

        private void SetBarImageFill(float newValue)
        {
            _fill.fillAmount = newValue;
        }
    }
}
