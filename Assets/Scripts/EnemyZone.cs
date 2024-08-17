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
    [SerializeField] private GameObject zoneCollectable;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private EnemyType enemyType;
    private int _fedEnemyCount;

    private BoxCollider _collider;

    public void AddScore(Transform enemyTransform)
    {
        if (++_fedEnemyCount == maxEnemyCount)
        {
            //Spawn collectable key nearby last killed enemy
            Instantiate(zoneCollectable, enemyTransform.position, Quaternion.identity);
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
}