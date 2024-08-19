using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private CharacterController _characterController;
    public Vector3 Direction { get; private set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Direction = new Vector3(horisontal, 0, vertical).normalized;

        Move(_speed * Time.deltaTime * Direction);
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction);
    }
}
