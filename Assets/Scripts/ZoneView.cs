using TMPro;
using UnityEngine;

public class ZoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text zoneStatisticText;
    
    public void UpdateText(int val, int maxVal)
    {
        zoneStatisticText.text = $"{val}/{maxVal}";
    }
}
