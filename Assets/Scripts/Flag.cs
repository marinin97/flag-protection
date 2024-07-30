using System;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public static event Action OnFlagDestroyed;
    public float detectionRadius = 1f; 
    public int requiredHits = 5; 
    public Transform FlagWavePart;

    private int _currentHits = 0; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _currentHits++;
            FlagWavePart.position += Vector3.down * 0.5f;
        }
        if (_currentHits >= requiredHits)
        {
            OnFlagDestroyed?.Invoke();
        }
    }     
}
