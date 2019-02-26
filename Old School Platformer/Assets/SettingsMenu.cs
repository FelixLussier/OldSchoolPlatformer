using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider sliderVolume;
    public Toggle boutonToggle;

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void

}
