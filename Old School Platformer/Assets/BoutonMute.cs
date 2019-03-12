using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoutonMute : MonoBehaviour
{
    public Slider sliderVolumeMaster;
    public Slider sliderVolumeSFX;
    public Slider sliderVolumeMusique;
    public Toggle muteMaster;
    public Toggle muteSFX;
    public Toggle muteMusic;
    private float volume;
    private float volumeMaster;
    private float volumeMusic;
    private float volumeSFX;
    private bool wasMuteMaster = false;
    private bool wasMuteMusic = false;
    private bool wasMuteSFX = false;

    private void Update()
    {
        sliderVolumeMaster = GameObject.Find("sliderMaster").GetComponent<Slider>();
        sliderVolumeSFX = GameObject.Find("sliderSound").GetComponent<Slider>();
        sliderVolumeMusique = GameObject.Find("sliderMusic").GetComponent<Slider>();
        muteMaster = GameObject.Find("muteMaster").GetComponent<Toggle>();
        muteMusic = GameObject.Find("muteMusic").GetComponent<Toggle>();
        muteSFX = GameObject.Find("muteSFX").GetComponent<Toggle>();


        if (wasMuteMaster == false)
        {
            volumeMaster = sliderVolumeMaster.value;
            volumeMusic = sliderVolumeMusique.value;
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
            wasMuteMaster = true;
        }

        if (muteMusic.isOn == true)
        {
            sliderVolumeMusique.value = -35;
            wasMuteMusic = true;
        }

        if (wasMuteMaster == true && muteMaster.isOn == false)
        {
            sliderVolumeMaster.value = volumeMaster;
            sliderVolumeMusique.value = volumeMusic;
            sliderVolumeSFX.value = volumeSFX;
            wasMuteMaster = false;
        }
    }


}
