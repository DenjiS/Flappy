using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    private const float MinScreenValue = 0f;
    private const float MaxScreenValue = 1f;

    [Header("Pool")]
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    [SerializeField] private float _enabledAreaExtension;

    private readonly List<GameObject> _pool = new();

    private float _minEnabledAreaDistance;
    private float _maxEnabledAreaDistance;

    public void ResetPool()
    {
        foreach (GameObject item in _pool)
            item.SetActive(false);
    }

    protected virtual void Awake()
    {
        _minEnabledAreaDistance = MinScreenValue - _enabledAreaExtension;
        _maxEnabledAreaDistance = MaxScreenValue + _enabledAreaExtension;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject instance = Instantiate(_template, _container.transform);
            ConfigureOnCreation(instance);

            instance.SetActive(false);

            _pool.Add(instance);
        }
    }

    protected virtual void ConfigureOnCreation(GameObject instance) { }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(result => result.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectsAbroadScreen()
    {
        foreach(GameObject item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector2 toScreenPosition = Camera.main.WorldToViewportPoint(item.transform.position);

                if (toScreenPosition.x < _minEnabledAreaDistance 
                    || toScreenPosition.x > _maxEnabledAreaDistance
                    || toScreenPosition.y < _minEnabledAreaDistance
                    || toScreenPosition.y > _maxEnabledAreaDistance)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
