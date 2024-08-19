using UnityEngine;

public enum EnemyType
{
    MonkeyType1,
    MonkeyType2,
    MonkeyType3
}

public class EnemyZone : MonoBehaviour
{
    private EnemyZoneManager _zoneManager;

    [Header("Enemy Settings")] 
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private EnemyType enemyType;

    [Header("Zone Statistic")] 
    [SerializeField] private GameObject totemObject;
    [SerializeField] private ZoneView _zoneView;

    private BoxCollider _collider;
    private Totem _totem;
    private int _fedEnemyCount;

    public void Initialize(EnemyZoneManager zoneManager)
    {
        _zoneManager = zoneManager;
        _totem.Initialize(this);
        _totem.UpdateText(0, maxEnemyCount);
        _zoneView.UpdateText(0, maxEnemyCount);
        //Debug
        AddScore();
    }

    private void Awake()
    {
        _totem = totemObject.GetComponentInChildren<Totem>();
    }

    public void AddScore()
    {
        if (++_fedEnemyCount == maxEnemyCount)
        {
            _totem.SetInteractionState(true);
        }
        _totem.UpdateText(_fedEnemyCount, maxEnemyCount);
        _zoneView.UpdateText(_fedEnemyCount, maxEnemyCount);
    }

    public void GatherKey()
    {
        _zoneManager.GatherCollectible();
    }
}