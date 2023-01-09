using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;
    [SerializeField] string SceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void SettingsGame()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}