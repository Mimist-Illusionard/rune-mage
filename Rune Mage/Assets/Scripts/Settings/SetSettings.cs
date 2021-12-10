using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    private Resolution resolution;

    public void ChangeFPS(int Input)
    {
        SettingsManager.Singleton.ChangeFPS(Input);
    }

    public void Resolution(Dropdown dropdown)
    {
        if (dropdown.value == 0) { resolution.width = 1920; resolution.height = 1080; }
        else if (dropdown.value == 1) { resolution.width = 1280; resolution.height = 1024; }
        else if (dropdown.value == 2) { resolution.width = 1024; resolution.height = 768; }

        SettingsManager.Singleton.Resolution(resolution);
        resolution = new Resolution();
    }

    public void ChangeCapture(Toggle toggle)
    {
        SettingsManager.Singleton.ChangeCapture(toggle.isOn);
    }

    public void ChangeSens(Slider slider)
    {
        SettingsManager.Singleton.ChangeSens(slider.value);
    }

    public void ChangeVolume(Slider slider)
    {
        SettingsManager.Singleton.ChangeVolume(slider.value);
    }

    public void ChangeMusicVolume(Slider slider)
    {
        SettingsManager.Singleton.ChangeMusicVolume(slider.value);
    }

    public void ChangeEffectVolume(Slider slider)
    {
        SettingsManager.Singleton.ChangeEffectVolume(slider.value);
    }
}
