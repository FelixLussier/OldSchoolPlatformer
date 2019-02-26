using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoutonMute : MonoBehaviour
{
    Slider sliderVolume;

    private void Start()
    {
        sliderVolume = GameObject.Find("Slider").GetComponent<Slider>();

        sliderVolume.value = -35;
        AudioListener.volume = -35;

    }

}
