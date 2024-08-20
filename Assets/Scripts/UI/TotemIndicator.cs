using UnityEngine;
using UnityEngine.UI;

public class TotemIndicator : MonoBehaviour
{
    [SerializeField] private Image[] _images;

    private void Start()
    {
        foreach (var image in _images)
        {
            image.gameObject.SetActive(false);
        }
    }

    public void UpdateImage(int totemCleared)
    {
        _images[totemCleared - 1].gameObject.SetActive(true);
    }
}
