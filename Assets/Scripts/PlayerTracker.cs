using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _xOffset, transform.position.y);
    }
}
