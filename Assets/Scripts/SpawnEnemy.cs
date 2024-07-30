using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    public float TimeBetweenWawes;
    public TMP_Text WaveCountdownText;

    private float _countDown = 5f;
    private int _waveNumber = 0;
    private FlagScript _flagScript;

    private void Start()
    {
        _flagScript = FindObjectOfType<FlagScript>();
    }

    private void Update()
    {
        if (_countDown <= 0)
        {            
            StartCoroutine(SpawnWave());
            _countDown = TimeBetweenWawes;
        }
        
        _countDown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Floor(_countDown).ToString();
    }

    private IEnumerator SpawnWave()
    {
        _waveNumber++;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnEnemies()
    {
        var enemyInstance = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        EnemyMovement enemy = enemyInstance.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            _flagScript.RegisterEnemy(enemy);
        }
    }

    //-----------------------------------------------------------------------------------------------
    //public GameObject[] prefabs; 
    //public Transform spawnPoint; 
    //public float delay = 2f; 

    //void Start()
    //{
    //    StartCoroutine(SpawnPrefabs());
    //}

    //IEnumerator SpawnPrefabs()
    //{
    //    foreach (GameObject prefab in prefabs)
    //    {
    //        GameObject spawnedPrefab = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

    //        Animator animator = spawnedPrefab.GetComponent<Animator>();

    //        if (animator != null)
    //        {
    //            animator.Play("WalkStickman");
    //        }

    //        yield return new WaitForSeconds(delay);
    //    }
    //}
}
