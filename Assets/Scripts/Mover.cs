using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.position = _startPosition;
    }
}
