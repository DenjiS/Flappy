using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Shooter, IMortal
{
    [SerializeField] private Transform _shootDirectionPoint;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private PlayerMovement _movement;
    private int _score = 0;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();

        InitializeShooter(_shootDirectionPoint, _bulletSpawner);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            Shoot();
        }
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }


    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _movement.ResetMovement();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
