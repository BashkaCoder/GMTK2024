using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    [Header("Gate states")]
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    private SpriteRenderer _image;

    private void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _image.sprite = openSprite;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _image.sprite = closedSprite;
    }
}
