using UnityEngine;

public abstract class TimedShooter : Shooter
{
    [SerializeField] private float _timeBetweenShots;

    private float _elapsed = 0;

    protected virtual void Update()
    {
        _elapsed += Time.deltaTime;
        
        if (_elapsed > _timeBetweenShots)
        {
            Shoot();
            _elapsed = 0;
        }
    }
}
