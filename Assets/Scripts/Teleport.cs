using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private TMP_Text _teleportText;
    [SerializeField] private Teleport _correspondingTeleport;
    public Transform spawnPoint;
    public bool canEnter;
    public bool bossTeleport;

    private const string canEnterText = "Press 'E' to enter area";
    private const string cannotEnterText = "You have to pray on altar";
    
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
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        _teleportText.gameObject.SetActive(false);
    }
}
