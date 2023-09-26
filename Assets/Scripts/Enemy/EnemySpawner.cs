using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [Header("Enemy configuration")]
    [SerializeField] private Player _player;
    [SerializeField] private BulletSpawner _bulletSpawner;

    [Header("Spawner")]
    [SerializeField] private float _spawnsDelay;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private WaitForSeconds _delay;

    private Coroutine _spawning;

    private void Start()
    {
        _delay = new WaitForSeconds(_spawnsDelay);
    }

    private void Update()
    {
        _spawning ??= StartCoroutine(Spawning());
    }

    protected override void ConfigureOnCreation(GameObject instance)
    {
        Enemy enemy = instance.GetComponent<Enemy>();
        enemy.Initialize(_player, _bulletSpawner);

        instance
            .GetComponent<Mover>()
            .SetDirection(Vector2.left);
    }

    private IEnumerator Spawning()
    {
        yield return _delay;

        Spawn();
    }

    private void Spawn()
    {
        if (TryGetObject(out GameObject result))
        {
            result.SetActive(true);

            float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
            Vector2 spawnPosition = new(transform.position.x, spawnPositionY);
            result.transform.position = spawnPosition;
        }

        DisableObjectsAbroadScreen();
    }
}
