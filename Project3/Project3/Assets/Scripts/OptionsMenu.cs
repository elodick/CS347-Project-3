﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
   public void SetVolume(float volume)
    {
        mixer.SetFloat("masterVolume", volume);
    }

    public void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
