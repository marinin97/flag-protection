using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnEnemyDestroyed;

    private void OnDestroy()
    {
        OnEnemyDestroyed?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("thorns"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("rotate"))
        {
            Destroy(gameObject);
        }
    }
}
