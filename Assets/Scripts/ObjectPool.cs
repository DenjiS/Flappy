using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    private Camera _camera;

    public void ResetPool()
    {
        foreach (GameObject item in _pool)
            item.SetActive(false);
    }

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

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
                Vector2 toScreenPosition = _camera.WorldToViewportPoint(item.transform.position);

                if (toScreenPosition.x < 0 || toScreenPosition.x > 1
                    || toScreenPosition.y < 0 || toScreenPosition.y > 1)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
