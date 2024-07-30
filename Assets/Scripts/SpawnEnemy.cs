using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    public float TimeBetweenWaves;
    public TMP_Text WaveCountdownText;

    private float _countDown = 1f;
    private int _waveNumber = 0;
    private Flag _flagScript;

    private void Start()
    {
        _flagScript = FindObjectOfType<Flag>();
    }

    private void Update()
    {
        if (_countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countDown = TimeBetweenWaves;
        }

        _countDown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Floor(_countDown).ToString();
    }

    private IEnumerator SpawnWave()
    {
        _waveNumber++;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemyInstance();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnEnemyInstance()
    {
        var enemyInstance = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        EnemyMovement enemy = enemyInstance.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            //_flagScript.RegisterEnemy(enemy);
        }
    }
}
