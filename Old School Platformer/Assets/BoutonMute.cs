using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoutonMute : MonoBehaviour
{
    public Slider sliderVolumeMaster = GameObject.Find("sliderMaster").GetComponent<Slider>();
    public Slider sliderVolumeSFX = GameObject.Find("sliderSound").GetComponent<Slider>();
    public Slider sliderVolumeMusique = GameObject.Find("sliderMusic").GetComponent<Slider>();
    public Toggle muteMaster = GameObject.Find("muteMaster").GetComponent<Toggle>();
    public Toggle muteSFX = GameObject.Find("muteSFX").GetComponent<Toggle>();
    public Toggle muteMusic = GameObject.Find("muteMusic").GetComponent<Toggle>();
    private float volume;
    private float volumeMaster;
    private float volumeMusic;
    private float volumeSFX;
    private bool wasMuteMaster = false;
    private bool wasMuteMusic = false;
    private bool wasMuteSFX = false;

    private void Start()
    {
        float tempMaster = PlayerPrefs.GetFloat("MasterVol");
        float tempMusic = PlayerPrefs.GetFloat("MusicVol");
        float tempSFX = PlayerPrefs.GetFloat("SFXVol");

        if(PlayerPrefs.GetInt("Apply") == 1)
        {
            sliderVolumeMaster.value = PlayerPrefs.GetFloat("MasterVol");
            sliderVolumeMusique.value = PlayerPrefs.GetFloat("MusicVol");
            sliderVolumeSFX.value = PlayerPrefs.GetFloat("MusicVol");
        }
        else
        {
            sliderVolumeMaster.value = tempMaster;
            sliderVolumeMusique.value = tempMusic;
            sliderVolumeSFX.value = tempSFX;
        }
        
    }

    private void Update()
    {
        if (wasMuteMaster == false)
        {
            volumeMaster = sliderVolumeMaster.value;
            volumeMusic = sliderVolumeMusique.value;
            volumeSFX = sliderVolumeSFX.value;
        }

        if (wasMuteMusic == false)
        {
            volumeMusic = sliderVolumeMusique.value;
        }

        if (wasMuteSFX == false)
        {
            volumeSFX = sliderVolumeSFX.value;
        }

        if (sliderVolumeMusique.value >= volumeMaster)
        {
            sliderVolumeMusique.value = volumeMaster;
        }

        if (sliderVolumeSFX.value >= volumeMaster)
        {
            sliderVolumeSFX.value = volumeMaster;
        }


        if (muteMaster.isOn == true)
        {
            sliderVolumeMaster.value = -35;
            sliderVolumeMusique.value = -35;
            sliderVolumeSFX.value = -35;
            wasMuteMaster = true;
            muteMusic.isOn = true;
            muteSFX.isOn = true;
        }

        if (wasMuteMaster == true && muteMaster.isOn == false)
        {
            sliderVolumeMaster.value = volumeMaster;
            sliderVolumeMusique.value = volumeMusic;
            sliderVolumeSFX.value = volumeSFX;
            muteMusic.isOn = false;
            muteSFX.isOn = false;
            wasMuteMaster = false;
        }

        if (muteMusic.isOn == true)
        {
            sliderVolumeMusique.value = -35;
            wasMuteMusic = true;
        }

        if (wasMuteMusic == true && muteMusic.isOn == false)
        {
            sliderVolumeMusique.value = volumeMusic;
            wasMuteMusic = false;
        }

        if (muteSFX.isOn == true)
        {
            sliderVolumeSFX.value = -35;
            wasMuteSFX = true;
        }

        if (wasMuteSFX == true && muteSFX.isOn == false)
        {
            sliderVolumeSFX.value = volumeSFX;
            wasMuteSFX = false;
        }
    }


}
