public class Enemy : TimedShooter, IMortal
{
    private Player _player;

    public void Initialize(Player player, BulletSpawner bullets)
    {
        _player = player;
        InitializeShooter(bullets);
    }

    public void Die()
    {
        _player.IncreaseScore();
        gameObject.SetActive(false);
    }
}
