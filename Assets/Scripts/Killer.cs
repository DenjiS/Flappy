using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IMortal mortal))
        {
            Debug.Log("touched");
            mortal.Die();
        }
    }
}
