using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BossZone : MonoBehaviour
{
    private EnemyZoneManager _zoneManager;
    private BoxCollider zoneTrigger;
    
    public void Initialize(EnemyZoneManager zoneManager)
    {
        _zoneManager = zoneManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"You can enter boss zone = {_zoneManager.AllCollectiblesCollected()}");
    }
}
