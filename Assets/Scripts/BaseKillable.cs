using UnityEngine;

public class BaseKillable : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Killer>(out _))
        {
            Destroy(gameObject);
        }
    }
}
