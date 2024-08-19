using System;
using UnityEngine;
using UnityEngine.UI;

public class TotemIndicator : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
    }

    public void UpdateImage(int totemCleared)
    {
        _image.color = new  Color(1.0f, 1.0f, 1.0f, 1.0f / 3.0f * totemCleared );
    }
}
