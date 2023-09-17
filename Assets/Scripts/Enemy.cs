using UnityEngine;

public class Enemy : MonoBehaviour, IMortal
{
    private Player _player;

    public void Init(Player player) =>
        _player = player;

    public void Die()
    {
        _player.IncreaseScore();
    }
}
