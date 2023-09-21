using UnityEngine;

public class Enemy : TimedShooter, IMortal
{
    [SerializeField] private float _minXShootRange;

    private Player _player;

    protected override void Update()
    {
        if (transform.position.x - _player.transform.position.x > _minXShootRange)
        {
            base.Update();
        }
    }

    public void Init(Player player, BulletSpawner bullets)
    {
        InitializeShooter(player.transform, bullets);
        _player = player;
    }

    public void Die()
    {
        _player.IncreaseScore();
        gameObject.SetActive(false);
    }
}
