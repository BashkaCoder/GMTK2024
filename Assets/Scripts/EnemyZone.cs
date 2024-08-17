using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyType
{
    Wolf,
    Boar,
    Spider
}

public class EnemyZone : MonoBehaviour
{
    private EnemyZoneManager _zoneManager;
    
    [Header("Enemy Settings")]
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private EnemyType enemyType;
    
    [Header("CollectablePrefab")]
    [SerializeField] private GameObject collectable;
    
    private int _fedEnemyCount;
    private BoxCollider _collider;

    public void Initialize(EnemyZoneManager zoneManager)
    {
        _zoneManager = zoneManager;
    }
    
    public void AddScore(Transform enemyTransform)
    {
        if (++_fedEnemyCount == maxEnemyCount)
        {
            SpawnCollectible(enemyTransform);
            // Add Action to collectible
        }
    }
    
    //For enemy wandering
    public Vector3 GetRandomPointInZone()
    {
        var bounds = _collider.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    private void SpawnCollectible(Transform enemyTransform)
    {
        print("Collectable has been spawned");
        var collectible = Instantiate(collectable, enemyTransform.position, Quaternion.identity).GetComponent<Collectible>();
        collectible.CollectAction = () =>
        {
            _zoneManager.GatherCollectible();
        };
    }
}