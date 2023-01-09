using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingsPanel;    
    public GameObject soundSettingsPanel;
    public GameObject videoSettingsPanel;      

    public void SoundSettings()
    {
        settingsPanel.SetActive(false);
        soundSettingsPanel.SetActive(true);
    }

    public void VideoSettings()
    {
        settingsPanel.SetActive(false);
        videoSettingsPanel.SetActive(true);
    }    

    public void BackMenu()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
