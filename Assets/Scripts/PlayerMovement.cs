using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _force = 5f;
    [SerializeField] private Score _score;
    
    private Rigidbody _rigidbody;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (!Input.GetMouseButtonDown(0)) return;
        _score.EnemyAppeared.Invoke('c', '+');
        // Получаем позицию мыши в мировых координатах
        var clickPosition = GetMouseWorldPosition();
        
        // Вычисляем направление к позиции и нормализуем его
        var direction = clickPosition - transform.position;
        direction.Normalize();

        // Вычисляем силу и применяем ее к Rigidbody с использованием импульса
        var force = direction * _force;
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out var hitInfo, 50f) ? hitInfo.point : Vector3.zero;
    }
    
    
}
