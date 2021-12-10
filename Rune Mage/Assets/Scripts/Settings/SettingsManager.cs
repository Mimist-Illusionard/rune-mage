using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer Mixer;

    public float MouseSentitive;

    private bool _fullScreen = true;

    public static SettingsManager Singleton;

    private Resolution _resolution;

    private void Awake()
    {
        Singleton = this;
        if (PlayerPrefs.HasKey("FPSLock"))
        {
            ChangeFPS(PlayerPrefs.GetInt("FPSLock"));
        }
        else
        {
            PlayerPrefs.SetInt("FPSLock", 144);
            ChangeFPS(144);
        }
        SetPrefs();
    }

    private void SetPrefs()
    {
        if (PlayerPrefs.HasKey("MasterVolume")) { ChangeVolume(PlayerPrefs.GetFloat("MasterVolume") + 0.8f); } else { PlayerPrefs.SetFloat("MasterVolume", ChangeVolume(0.8f)); }
        if (PlayerPrefs.HasKey("MusicVolume")) { ChangeVolume(PlayerPrefs.GetFloat("MusicVolume") + 0.8f); } else { PlayerPrefs.SetFloat("MusicVolume", ChangeVolume(0.8f)); }
        if (PlayerPrefs.HasKey("EffectsVolume")) { ChangeVolume(PlayerPrefs.GetFloat("EffectsVolume") + 0.8f); } else { PlayerPrefs.SetFloat("EffectsVolume", ChangeVolume(0.8f)); }
        if (PlayerPrefs.HasKey("Sens")) { ChangeSens(PlayerPrefs.GetFloat("Sens")); } else { PlayerPrefs.SetFloat("Sens", 2); }
        if (PlayerPrefs.HasKey("ResW") && PlayerPrefs.HasKey("ResH")) { _resolution.width = PlayerPrefs.GetInt("ResW"); _resolution.height = PlayerPrefs.GetInt("ResH"); Resolution(_resolution); } else { PlayerPrefs.SetInt("ResW", Screen.currentResolution.width); PlayerPrefs.SetInt("ResH", Screen.currentResolution.height); Resolution(_resolution); }
    }

    public void ChangeFPS(int Input)
    {
        Application.targetFrameRate = Input;
        PlayerPrefs.SetInt("FPSLock", Input);
    }

    public void Resolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, _fullScreen);
    }

    public void ChangeCapture(bool fullscreen)
    {
        _fullScreen = fullscreen;
    }

    public void ChangeSens(float Sens)
    {
        MouseSentitive = Sens;
        PlayerPrefs.SetFloat("Sens", MouseSentitive);
    }

    public float ChangeVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("MasterVolume", value);
        Mixer.SetFloat("Master Volume", value * 100);
        return value;
    }

    public float ChangeMusicVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("MusicVolume", value);
        Mixer.SetFloat("Music Volume", value * 100);
        return value;
    }

    public float ChangeEffectVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("EffectsVolume", value);
        Mixer.SetFloat("Effects Volume", value * 100);
        return value;
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
