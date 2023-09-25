using UnityEngine.Events;

public class Enemy : TimedShooter, IMortal
{
    public event UnityAction Died;

    public void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
