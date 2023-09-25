using UnityEngine;

public class TopBorderShooter : TimedShooter
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void Start()
    {
        InitializeShooter(_bulletSpawner);
    }
}
