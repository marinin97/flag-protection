using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;
    public Button LevelsButton;
    public GameObject LevelsPanel;
    public Button[] LevelsButtons;

    private void Awake()
    {
        StartButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        ExitButton.onClick.AddListener(() => Application.Quit());
        LevelsPanel.SetActive(false);
        LevelsButton.onClick.AddListener(()=> LevelsPanel.SetActive(!LevelsPanel.activeSelf));
        LevelsButtons[0].onClick.AddListener(() =>SceneManager.LoadScene(1));
        LevelsButtons[1].onClick.AddListener(() =>SceneManager.LoadScene(2));
        LevelsButtons[2].onClick.AddListener(() =>SceneManager.LoadScene(3));
    }
}
