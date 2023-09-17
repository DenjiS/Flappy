using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IMortal
{
    private PlayerMovement _movement;
    private int _score = 0;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void IncreaseScore() =>
        _score++;

    public void ResetPosition() =>
        _movement.ResetPosition();

    public void Die()
    {
        Time.timeScale = 0;
    }
}
