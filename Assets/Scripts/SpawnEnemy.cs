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
    public TMP_Text CurrentNumberOfWaveText;

    private float _countDown;
    private int _waveNumber = 0;

    private void Update()
    {
        if (_countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countDown = TimeBetweenWaves;
        }

        _countDown -= Time.deltaTime;
        WaveCountdownText.text = $" {_countDown:F0} s";
        CurrentNumberOfWaveText.text = "wave: " + _waveNumber.ToString();
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(10f);
        _waveNumber++;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemyInstance();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemyInstance()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
