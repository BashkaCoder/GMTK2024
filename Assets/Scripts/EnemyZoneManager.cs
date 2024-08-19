using BananaForScale;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyZoneManager : MonoBehaviour
{
    [Header("Zones")]
    [SerializeField] private EnemyZone wolfZone;
    [SerializeField] private EnemyZone boarZone;
    [SerializeField] private EnemyZone spiderZone;
    [SerializeField] private BossZone _bossZone;

    [FormerlySerializedAs("collectiblesMaxCount")]
    [Header("Collectibles")]
    [SerializeField] private int zonesMaxCount;
    private int _zonesCleared;

    [Header("Totems")]
    [SerializeField] private TotemIndicator _totemIndicator;
    
    private static Dictionary<EnemyType, EnemyZone> _zones;

    private void Start()
    {
        _zonesCleared = 0;
        
        _zones = new Dictionary<EnemyType, EnemyZone>()
        {
            {EnemyType.MonkeyType1, wolfZone},
            {EnemyType.MonkeyType2, boarZone},
            {EnemyType.MonkeyType3, spiderZone}
        };
        
        foreach (var pair in _zones)
        {
            var zone = pair.Value;
            zone.Initialize(this);
        }

        _bossZone.Initialize(this);
        _totemIndicator.UpdateImage(0);
    }

    public static void IncreaseFullFeedEnemyCount(EnemyType type)
    {
        _zones[type].AddScore();
    }

    public void GatherCollectible()
    {
        print("Collectable gathered");
        _zonesCleared++;
        _totemIndicator.UpdateImage(_zonesCleared);
    }

    public bool AllCollectiblesCollected() => _zonesCleared == zonesMaxCount;
}