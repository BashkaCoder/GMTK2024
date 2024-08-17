using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneManager : MonoBehaviour
{
    [Header("Zones")]
    [SerializeField] private EnemyZone wolfZone;
    [SerializeField] private EnemyZone boarZone;
    [SerializeField] private EnemyZone spiderZone;
    [SerializeField] private BossZone _bossZone;

    [Header("Collectibles")]
    [SerializeField] private int collectiblesMaxCount;
    private int _collectiblesGathered;
    
    private Dictionary<EnemyType, EnemyZone> _zones;

    private void Start()
    {
        _zones = new Dictionary<EnemyType, EnemyZone>()
        {
            {EnemyType.Wolf, wolfZone},
            {EnemyType.Boar, boarZone},
            {EnemyType.Spider, spiderZone}
        };

        foreach (var pair in _zones)
        {
            pair.Value.Initialize(this);
        }
        _bossZone.Initialize(this);
    }

    //Call when enemy fully feed
    public void FeedEnemy(EnemyType type, Transform enemyTransform)
    {
        //For now null
        _zones[type].AddScore(enemyTransform);
    }

    public void GatherCollectible()
    {
        print("Collectable gathered");
        _collectiblesGathered++;
    }

    public bool AllCollectiblesCollected() => _collectiblesGathered == collectiblesMaxCount;
}