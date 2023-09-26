using System.Collections;
using UnityEngine;

public abstract class TimedShooter : Shooter
{
    [SerializeField] private float _timeBetweenShots;

    private WaitForSeconds _delay;

    private Coroutine _ñoroutine;

    private void Awake()
    {
        _delay = new WaitForSeconds(_timeBetweenShots);
    }

    protected virtual void Update()
    {
        _ñoroutine ??= StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        yield return _delay;

        Shoot();
    }
}
