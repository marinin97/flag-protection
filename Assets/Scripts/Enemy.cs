using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnEnemyDestroyed;

    private void OnDestroy()
    {
        OnEnemyDestroyed?.Invoke(this);
    }
}
