using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneManager : MonoBehaviour
{
    [SerializeField] private EnemyZone wolfZone;
    [SerializeField] private EnemyZone boarZone;
    [SerializeField] private EnemyZone spiderZone;

    private Dictionary<EnemyType, EnemyZone> _zones;

    private void Start()
    {
        _zones = new Dictionary<EnemyType, EnemyZone>()
        {
            {EnemyType.Wolf, wolfZone},
            {EnemyType.Boar, boarZone},
            {EnemyType.Spider, spiderZone}
        };
    }

    public void FeedEnemy(EnemyType type, Transform enemyTransform)
    {
        //For now null
        _zones[type].AddScore(enemyTransform);
    }
    
}
