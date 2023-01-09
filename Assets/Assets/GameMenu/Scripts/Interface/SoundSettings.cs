using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider allVolume;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider effectVolume;
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject soundSettingsPanel;
    private float startVolume, startMusic, startEffect;

    private void Start()
    {
        Load();
        startVolume = allVolume.value;
        startMusic = musicVolume.value;
        startEffect = effectVolume.value;        
    }

    void Load()
    {
        allVolume.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        effectVolume.value = PlayerPrefs.GetFloat("EffectVolume");
    }

    public void SetAllVolume()
    {
        masterMixer.SetFloat("MasterVolume", allVolume.value);        
    }

    public void SetMusicVolume()
    {
        masterMixer.SetFloat("MusicVolume", musicVolume.value);
    }

    public void SetEffectsVolume()
    {
        masterMixer.SetFloat("EffectVolume", effectVolume.value);
    }

    public void ApplySettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", allVolume.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
        PlayerPrefs.SetFloat("EffectVolume", effectVolume.value);
        startVolume = allVolume.value;
        startMusic = musicVolume.value;
        startEffect = effectVolume.value;
    }

    public void Back()
    {
        allVolume.value = startVolume;
        musicVolume.value = startMusic;
        effectVolume.value = startEffect;
        soundSettingsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
