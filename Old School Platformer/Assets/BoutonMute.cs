using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoutonMute : MonoBehaviour
{
    public Slider sliderVolume;
    public Toggle muteButton;
    private float volume;
    private bool wasMute = false;

    private void Update()
    {
        sliderVolume = GameObject.Find("Slider").GetComponent<Slider>();
        muteButton = GameObject.Find(this.name).GetComponent<Toggle>();

        if(wasMute == false)
        {
            volume = sliderVolume.value;
        }

        if(muteButton.isOn == true)
        {
            sliderVolume.value = -35;
            wasMute = true;
        }

        if(wasMute == true && muteButton.isOn == false)
        {
            sliderVolume.value = volume;
            wasMute = false;
        }
    }


}
