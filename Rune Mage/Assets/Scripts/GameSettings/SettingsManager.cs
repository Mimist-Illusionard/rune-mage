using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerGroup Main;
    public AudioMixerGroup Music;
    public AudioMixerGroup Effects;

    public float MouseSentitive;

    private bool FullScreen = true;

    public static SettingsManager Singleton;

    private Resolution esolution;

    private void Awake()
    {
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
        if (PlayerPrefs.HasKey("Sens")) { ChangeSens(PlayerPrefs.GetFloat("Sens")); } else { PlayerPrefs.SetFloat("Sens", 1); }
        if (PlayerPrefs.HasKey("ResW") && PlayerPrefs.HasKey("ResH")) { esolution.width = PlayerPrefs.GetInt("ResW"); esolution.height = PlayerPrefs.GetInt("ResH"); Resolution(esolution); } else { PlayerPrefs.SetInt("ResW", Screen.currentResolution.width); PlayerPrefs.SetInt("ResH", Screen.currentResolution.height); Resolution(esolution); }
    }

    public void ChangeFPS(int Input)
    {
        Application.targetFrameRate = Input;
        PlayerPrefs.SetInt("FPSLock", Input);
    }

    public void Resolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, FullScreen);
    }

    public void ChangeCapture(bool fullscreen)
    {
        FullScreen = fullscreen;
    }

    public void ChangeSens(float Sens)
    {
        MouseSentitive = Sens;
        PlayerPrefs.SetFloat("Sens", MouseSentitive);
    }

    public float ChangeVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("MasterVolume", ChangeVolume(value));
        mixer.SetFloat(Main.name, value * 100);
        return value;
    }

    public float ChangeMusicVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("MusicVolume", ChangeVolume(value));
        mixer.SetFloat(Music.name, value * 100);
        return value;
    }

    public float ChangeEffectVolume(float Input)
    {
        float value = Input - 0.8f;
        PlayerPrefs.SetFloat("EffectsVolume", ChangeVolume(value));
        mixer.SetFloat(Main.name, value * 100);
        return value;
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
