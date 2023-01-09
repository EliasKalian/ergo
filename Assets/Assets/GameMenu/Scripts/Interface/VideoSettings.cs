using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class VideoSettings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutions;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Dropdown quality;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private Button applyButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject videoSettingsPanel;
    private Resolution[] resolutionsList;

    private void Awake()
    {
        resolutionsList = Screen.resolutions;
        List<Resolution> res = new List<Resolution>();
        int hz = resolutionsList[resolutionsList.Length - 1].refreshRate;
        for (int i = 0; i < resolutionsList.Length; i++)
        {
            if (resolutionsList[i].refreshRate == hz)
            {
                res.Add(resolutionsList[i]);
            }
        }
        resolutionsList = res.ToArray();
        Load();
        BuildMenu();
    }

    void Load()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));        
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("vSync", QualitySettings.vSyncCount);
        vSyncToggle.isOn = (QualitySettings.vSyncCount > 0) ? true : false;
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    void Save()
    {
        PlayerPrefs.SetInt("vSync", QualitySettings.vSyncCount);
        PlayerPrefs.SetInt("Quality", quality.value);
        PlayerPrefs.Save();
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

    void RefreshDropdown()
    {
        resolutions.RefreshShownValue();
    }

    void BuildMenu()
    {
        resolutions.options = new List<Dropdown.OptionData>();
        for (int i = 0; i < resolutionsList.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = ResToString(resolutionsList[i]);
            resolutions.options.Add(option);
            if (resolutionsList[i].height == Screen.height && resolutionsList[i].width == Screen.width) resolutions.value = i;
        }
        quality.ClearOptions();
        quality.AddOptions(QualitySettings.names.ToList());
        quality.value = PlayerPrefs.GetInt("Quality");
    }

    public void ApplySettings()
    {
        Screen.SetResolution(resolutionsList[resolutions.value].width, resolutionsList[resolutions.value].height, fullscreenToggle.isOn);
        QualitySettings.SetQualityLevel(quality.value);
        QualitySettings.vSyncCount = (vSyncToggle.isOn) ? 1 : 0;
        Save();
    }

    public void Back()
    {
        videoSettingsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
