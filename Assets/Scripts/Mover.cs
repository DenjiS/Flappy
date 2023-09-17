using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }
}
