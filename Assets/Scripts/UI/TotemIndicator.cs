using UnityEngine;
using UnityEngine.UI;

public class TotemIndicator : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;

    public void UpdateImage(int totemCleared)
    {
        _image.sprite = _sprites[totemCleared];
        //_image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f / 3.0f * totemCleared);
    }
}
