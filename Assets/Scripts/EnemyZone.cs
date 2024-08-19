using BananaForScale;
using BananaForScale.Attributes;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    private EnemyZoneManager _zoneManager;

    [Header("Enemy Settings")] 
    [SerializeField] private EnemyType enemyType;

    [Header("Zone Statistic")] 
    [SerializeField] private GameObject totemObject;
    [SerializeField] private ZoneView _zoneView;

    private int _enemyCount;
    private BoxCollider _collider;
    private Totem _totem;
    private int _fedEnemyCount;

    private void Awake()
    {
        _totem = totemObject.GetComponentInChildren<Totem>();
    }

    private int CalculateEnemyCount()
    {
        int enemyCount = 0;
        foreach (var enemy in FindObjectsOfType<Satiety>())
        {
            if (enemy.Type == enemyType) enemyCount++;
        }
        return enemyCount;
    }

    public void Initialize(EnemyZoneManager zoneManager)
    {
        _enemyCount = CalculateEnemyCount();

        _zoneManager = zoneManager;
        _totem.Initialize(this);
        _totem.UpdateText(0, _enemyCount);
        _zoneView.UpdateText(0, _enemyCount);
    }

    public void AddScore()
    {
        if (++_fedEnemyCount == _enemyCount)
        {
            _totem.SetInteractionState(true);
        }
        _totem.UpdateText(_fedEnemyCount, _enemyCount);
        _zoneView.UpdateText(_fedEnemyCount, _enemyCount);
    }

    public void GatherKey()
    {
        _zoneManager.GatherCollectible();
    }
}