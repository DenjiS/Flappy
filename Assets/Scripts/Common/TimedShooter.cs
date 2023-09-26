using System.Collections;
using UnityEngine;

public abstract class TimedShooter : Shooter
{
    [SerializeField] private float _timeBetweenShots;

    private WaitForSeconds _delay;

    private Coroutine _�oroutine;

    private void Awake()
    {
        _delay = new WaitForSeconds(_timeBetweenShots);
    }

    protected virtual void Update()
    {
        _�oroutine ??= StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        yield return _delay;

        Shoot();
    }
}
