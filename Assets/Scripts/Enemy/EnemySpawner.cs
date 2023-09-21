using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [Header("Enemy configuration")]
    [SerializeField] private Player _player;
    [SerializeField] private BulletSpawner _bulletSpawner;

    [Header("Spawner")]
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private WaitForSeconds _spawningDelay;

    private Coroutine _spawning;

    protected override void Awake()
    {
        base.Awake();

        _spawningDelay = new WaitForSeconds(_secondsBetweenSpawn);
    }

    private void Update()
    {
        _spawning ??= StartCoroutine(Spawning());
    }

    protected override void ConfigureOnCreation(GameObject instance)
    {
        instance
            .GetComponent<Enemy>()
            .Init(_player, _bulletSpawner);

        instance
            .GetComponent<Mover>()
            .SetDirection(Vector2.left);
    }

    private IEnumerator Spawning()
    {
        yield return _spawningDelay;

        if (TryGetObject(out GameObject result))
        {
            result.SetActive(true);

            float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
            Vector2 spawnPosition = new(transform.position.x, spawnPositionY);
            result.transform.position = spawnPosition;
        }

        DisableObjectsAbroadScreen();

        _spawning = null;
    }
}
