using UnityEngine;

public abstract 
    class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;

    private Transform _target;
    private BulletSpawner _bullets;

    protected void InitializeShooter(Transform target, BulletSpawner bullets)
    {
        _target = target;
        _bullets = bullets;
    }

    protected void Shoot()
    {
        _bullets.LaunchBullet(_bulletSpawnPoint.position, _target.position);
    }
}
