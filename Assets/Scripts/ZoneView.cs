using TMPro;
using UnityEngine;

public class ZoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text zoneStatisticText;
    
    public void UpdateText(int value, int maxValue)
    {
        zoneStatisticText.text = $"{value}/{maxValue}";
    }
}
