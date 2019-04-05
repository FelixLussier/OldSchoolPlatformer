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
    private float volumeMaster;
    private float volumeMusic;
    private float volumeSFX;
    private bool wasMuteMaster = false;
    private bool wasMuteMusic = false;
    private bool wasMuteSFX = false;

    private void Start()
    {
        sliderVolumeMaster = GameObject.Find("sliderMaster").GetComponent<Slider>();
        sliderVolumeSFX = GameObject.Find("sliderSound").GetComponent<Slider>();
        sliderVolumeMusique = GameObject.Find("sliderMusic").GetComponent<Slider>();
        muteMaster = GameObject.Find("muteMaster").GetComponent<Toggle>();
        muteSFX = GameObject.Find("muteSFX").GetComponent<Toggle>();
        muteMusic = GameObject.Find("muteMusic").GetComponent<Toggle>();

        sliderVolumeMaster.value = PlayerPrefs.GetFloat("MasterVol");
        sliderVolumeMusique.value = PlayerPrefs.GetFloat("MusicVol");
        sliderVolumeSFX.value = PlayerPrefs.GetFloat("SFXVol");
        if (PlayerPrefs.GetInt("wasMuteMaster") == 0) wasMuteMaster = false;
        else wasMuteMaster = true;
        if (PlayerPrefs.GetInt("wasMuteMusic") == 0) wasMuteMusic = false;
        else wasMuteMusic = true;
        if (PlayerPrefs.GetInt("wasMuteSFX") == 0) wasMuteSFX = false;
        else wasMuteSFX = true;
        if (PlayerPrefs.GetInt("muteMaster") == 0) muteMaster.isOn = false;
        else muteMaster.isOn = true;
        if (PlayerPrefs.GetInt("muteMusic") == 0) muteMusic.isOn = false;
        else muteMusic.isOn = true;
        if (PlayerPrefs.GetInt("muteSFX") == 0) muteSFX.isOn = false;
        else muteSFX.isOn = true;
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
            PlayerPrefs.SetInt("muteMaster", 1);
            PlayerPrefs.SetInt("muteMusic", 1);
            PlayerPrefs.SetInt("muteVol", 1);
            PlayerPrefs.SetInt("wasMuteMaster", 1);
        }

        if (wasMuteMaster == true && muteMaster.isOn == false)
        {
            sliderVolumeMaster.value = volumeMaster;
            sliderVolumeMusique.value = volumeMusic;
            sliderVolumeSFX.value = volumeSFX;
            muteMusic.isOn = false;
            muteSFX.isOn = false;
            wasMuteMaster = false;
            PlayerPrefs.SetInt("muteMaster", 0);
            PlayerPrefs.SetInt("muteMusic", 0);
            PlayerPrefs.SetInt("muteVol", 0);
            PlayerPrefs.SetInt("wasMuteMaster", 0);
        }

        if (muteMusic.isOn == true)
        {
            sliderVolumeMusique.value = -35;
            wasMuteMusic = true;
            PlayerPrefs.SetInt("muteMusic", 1);
            PlayerPrefs.SetInt("wasMuteMusic", 1);
        }

        if (wasMuteMusic == true && muteMusic.isOn == false)
        {
            sliderVolumeMusique.value = volumeMusic;
            wasMuteMusic = false;
            PlayerPrefs.SetInt("muteMusic", 0);
            PlayerPrefs.SetInt("wasMuteMusic", 0);
        }

        if (muteSFX.isOn == true)
        {
            sliderVolumeSFX.value = -35;
            wasMuteSFX = true;
            PlayerPrefs.SetInt("muteSFX", 1);
            PlayerPrefs.SetInt("wasMuteSFX", 1);
        }

        if (wasMuteSFX == true && muteSFX.isOn == false)
        {
            sliderVolumeSFX.value = volumeSFX;
            wasMuteSFX = false;
            PlayerPrefs.SetInt("muteSFX", 0);
            PlayerPrefs.SetInt("wasMuteSFX", 0);
        }

    }


}
