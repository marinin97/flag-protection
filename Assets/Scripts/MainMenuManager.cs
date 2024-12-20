using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;
    public Button LevelsButton;
    public Button[] LevelsButtons;
    public GameObject LevelsPanel;

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
