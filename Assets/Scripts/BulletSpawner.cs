using System.Collections;
using UnityEngine;

public class BulletSpawner : ObjectPool
{
    [SerializeField] private float _timeBetweenDisablings;

    private WaitForSeconds _disablingsDelay;

    private Coroutine _regularDisabling;

    private void Start()
    {
        _disablingsDelay = new WaitForSeconds(_timeBetweenDisablings);
    }

    private void Update()
    {
        _regularDisabling ??= StartCoroutine(Disabling());
    }

    public void LaunchBullet(Vector2 spawnPosition, Vector2 moveDirectionPoint)
    {
        if (TryGetObject(out GameObject result))
        {
            result.SetActive(true);
            result.transform.position = spawnPosition;

            result
                .GetComponent<Mover>()
                .SetDirection(moveDirectionPoint - spawnPosition);
        }
    }

    private IEnumerator Disabling()
    {
        yield return _disablingsDelay;

        DisableObjectsAbroadScreen();

        _regularDisabling = null;
    }
}
