using UnityEngine;
using UnityEngine.UI;

public class hunger : MonoBehaviour
{
    public Image image;

    public void AddHunger(float amount)
    {
        image.fillAmount = Mathf.Clamp01(image.fillAmount + amount);
    }

}
