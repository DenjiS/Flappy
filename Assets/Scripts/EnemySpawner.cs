using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [Header("Spawner")]
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private WaitForSeconds _delay;

    private Coroutine _spawning;

    private void Awake()
    {
        Initialize(_template);
        _delay = new WaitForSeconds(_secondsBetweenSpawn);
    }

    private void Update()
    {
        _spawning ??= StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        yield return _delay;

        if (TryGetObject(out GameObject result))
        {
            float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
            Vector2 spawnPosition = new(transform.position.x, spawnPositionY);

            result.transform.position = spawnPosition;
            result.SetActive(true);

            result.GetComponent<Mover>().SetDirection(Vector2.left);

            DisableObjectsAbroadScreen();
        }

        _spawning = null;
    }
}
