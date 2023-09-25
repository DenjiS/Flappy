using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Transform _bulletDirectionPoint;

    private BulletSpawner _bullets;

    protected void InitializeShooter(BulletSpawner bullets)
    {
        _bullets = bullets;
    }

    protected void Shoot()
    {
        _bullets.LaunchBullet(_bulletSpawnPoint.position, _bulletDirectionPoint.position);
    }
}
