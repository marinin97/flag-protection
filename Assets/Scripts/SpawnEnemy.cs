using System.Collections;
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
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

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
            yield return new WaitForSeconds(0.4f);
        }
    }

    private void SpawnEnemyInstance()
    {
        var enemyInstance = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();
        if (enemy != null)
        {
            _levelManager.RegisterEnemy(enemy);
        }
    }
}
