using UnityEngine;

public class SpawnPlace : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private const float FixedDistance = 5f; // ������������� ���������� �� ������������� �������

    private void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // ��������� ����������� �� ������������� ������� � �������
        Vector3 direction = (worldMousePosition - _parent.position).normalized;

        // ������������� ������� ��������� ������� �� ������������� ���������� �� ������������� �������
        transform.position = _parent.position + direction * FixedDistance;

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
        //    var direction = hit.point - transform.position;
        //    direction.y = transform.position.y;
        //    if (Vector3.Distance(direction, transform.position) > 10f) return;
        //    transform.position = direction;
        //}

        
    }
}
