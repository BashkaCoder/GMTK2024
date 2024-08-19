using UnityEngine;
using UnityEngine.UI;

public class BossGate : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    
    [Header("Zone Manager")]
    [SerializeField] private EnemyZoneManager zoneManager;
    
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

        if (zoneManager.AllCollectiblesCollected())
        {
            _collider.enabled = false;
            _image.sprite = openSprite;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _image.sprite = closedSprite;
    }
}
