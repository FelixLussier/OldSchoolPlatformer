using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mixerMusic;
    public AudioMixer mixerSFX;

    public void ChangeVolumeSFX(float volume)
    {
        mixerSFX.SetFloat("volume", volume);
    }

    public void ChangeVolumeMusic(float volume)
    {
        mixerMusic.SetFloat("volume", volume);
    }
}
