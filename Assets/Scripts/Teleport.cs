using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private EnemyZone _zone;
    [SerializeField] private TMP_Text _teleportText;
    [SerializeField] private Teleport _correspondingTeleport;
    [SerializeField] private Sprite _openDoorSprite;
    [SerializeField] private Sprite _closedDoorSprite;
    public Transform spawnPoint;
    public bool canEnter;
    public bool shouldEnableZoneView;
    public bool shouldCloseDoor;

    private string canEnterText = "Press 'E' to enter area";
    private string cannotEnterText = "You have to pray on altar";
    
    private void Start()
    {
        if (canEnter) GetComponent<SpriteRenderer>().sprite = _openDoorSprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _teleportText.gameObject.SetActive(true);
        _teleportText.text = canEnter ? canEnterText : cannotEnterText;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (canEnter && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.transform.position = _correspondingTeleport.spawnPoint.position;
            ZoneView.Instance.gameObject.SetActive(shouldEnableZoneView);
            if (_zone != null)
            {
                _zone.UpdateZoneView();
            }

            if (shouldCloseDoor)
            {
                _correspondingTeleport.CloseDoor();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _teleportText.gameObject.SetActive(false);
    }
    
    public void OperDoor() =>  GetComponent<SpriteRenderer>().sprite = _openDoorSprite;

    public void CloseDoor()
    {
        GetComponent<SpriteRenderer>().sprite = _closedDoorSprite;
        _correspondingTeleport.canEnter = false;
        canEnter = false;
        cannotEnterText = "You've complete the dungeon";
        _correspondingTeleport.cannotEnterText = cannotEnterText = "You've complete the dungeon";
        ZoneView.Instance.gameObject.SetActive(false);
    }
}
