using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private EnemyMovement _enemy;

    private void Start()
    {
        StartCoroutine(FindEnemy());
    }

    private void Update()
    {
        StartCoroutine(CheckDistance());
    }
    public void RegisterEnemy(EnemyMovement enemy)
    {
        _enemy = enemy;
    }
    private IEnumerator FindEnemy()
    {
        yield return new WaitUntil(() => _enemy = FindObjectOfType<EnemyMovement>());
        RegisterEnemy(_enemy);
    }
    private IEnumerator CheckDistance()
    {
        while (_enemy != null)
        {
            if (Vector3.Distance(transform.position, _enemy.transform.position) <= 0.01f)
            {
                Debug.Log("ËND");

            }
            yield return null;
            Debug.Log("ËND22222");
        }

    }

}
