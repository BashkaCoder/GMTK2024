using UnityEngine;
using UnityEngine.UI;

public class TotemIndicator : MonoBehaviour
{
    [SerializeField] private Image[] _images;

    public void UpdateImage(int totemCleared)
    {
        _images[totemCleared-1].gameObject.SetActive(true);
    }
}
