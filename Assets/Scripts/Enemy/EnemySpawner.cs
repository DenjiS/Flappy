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

    private float _elapsed = 0;

    private void Update()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed > _secondsBetweenSpawn)
        {
            Spawn();
            _elapsed = 0;
        }
    }

    protected override void ConfigureOnCreation(GameObject instance)
    {
        Enemy enemy = instance.GetComponent<Enemy>();
        enemy.Initialize(_player, _bulletSpawner);

        instance
            .GetComponent<Mover>()
            .SetDirection(Vector2.left);
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
