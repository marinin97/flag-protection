using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button PauseButton;
    public Button ResumeButton;
    public Button RestartButton;
    public Button NextLevelButton;
    public Button[] MenuButtons;

    public GameObject WinLevelPanel;
    public GameObject EndLevelPanel;
    public GameObject PausePanel;

    public TMP_Text _remainCountEnemiesText;

    [SerializeField]private int _victoryCondition = 5;
    private int _destroyedEnemiesCount = 0;
    private List<Enemy> _enemies;

    private void Awake()
    {
        Time.timeScale = 1f;
        PauseButton.onClick.AddListener(PauseGame);
        ResumeButton.onClick.AddListener(ResumeGame);
        RestartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        NextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

        for (int i = 0; i < MenuButtons.Length; i++)
        {
            MenuButtons[i].onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        _remainCountEnemiesText.text = $"REMAIN COUNT: {_victoryCondition} kills";
    }

    private void OnEnable()
    {
        Flag.OnFlagDestroyed += EndLevel;
    }

    private void OnDisable()
    {
        Flag.OnFlagDestroyed -= EndLevel;
    }

    public void RegisterEnemy(Enemy enemy)
    {
        if (_enemies == null)
        {
            _enemies = new List<Enemy>();
        }

        if (!_enemies.Contains(enemy))
        {
            _enemies.Add(enemy);
            enemy.OnEnemyDestroyed += HandleEnemyDestroyed;
        }
    }

    private void HandleEnemyDestroyed(Enemy enemy)
    {
        enemy.OnEnemyDestroyed -= HandleEnemyDestroyed;
        _destroyedEnemiesCount++;
        int remainCount = _victoryCondition - _destroyedEnemiesCount;
        _remainCountEnemiesText.text = $"REMAIN COUNT: {remainCount} kills";
        if (_destroyedEnemiesCount >= _victoryCondition)
        {
            WinLevel();
        }
    }

    private void EndLevel()
    {
        if (EndLevelPanel == null)
        {
            return;
        }
        EndLevelPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void WinLevel()
    {
        if (WinLevelPanel == null)
        {
            return;
        }
        WinLevelPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public bool MenuActivePanels()
    {
        return PausePanel.activeSelf || WinLevelPanel.activeSelf || EndLevelPanel.activeSelf;
    }
}
