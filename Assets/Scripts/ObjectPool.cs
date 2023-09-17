using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _size;

    private void Awake()
    {
        
    }
}
