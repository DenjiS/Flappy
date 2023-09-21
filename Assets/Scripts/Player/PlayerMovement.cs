using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _tapForce;

    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;

    private Vector2 _initialPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _initialPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)
            && Time.timeScale > 0)
        {
            _rigidbody.velocity = Vector2.zero;
            transform.rotation = _maxRotation;
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Impulse);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetMovement()
    {
        transform.SetPositionAndRotation(_initialPosition, Quaternion.Euler(Vector3.zero));
        _rigidbody.velocity = Vector2.zero;
    }
}
