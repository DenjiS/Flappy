using System.Collections;
using UnityEngine;

public abstract class TimedShooter : Shooter
{
    [SerializeField] private float _timeBetweenShots;

    private WaitForSeconds _delay;

    private Coroutine _shooting;

    private void Awake()
    {
        _delay = new WaitForSeconds(_timeBetweenShots);
    }

    private void OnEnable()
    {
        _shooting = StartCoroutine(Shooting());
    }

    protected virtual void Update()
    {
        _shooting ??= StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        yield return _delay;

        Shoot();

        _shooting = null;
    }
}
