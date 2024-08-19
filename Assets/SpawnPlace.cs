using UnityEngine;

public class SpawnPlace : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private const float FixedDistance = 5f; // Фиксированное расстояние от родительского объекта

    private void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Вычисляем направление от родительского объекта к курсору
        Vector3 direction = (worldMousePosition - _parent.position).normalized;

        // Устанавливаем позицию дочернего объекта на фиксированном расстоянии от родительского объекта
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
