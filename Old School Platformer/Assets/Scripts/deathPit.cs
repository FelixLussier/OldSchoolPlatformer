using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathPit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.SetFloat("PlayerPosX", -7);
        PlayerPrefs.SetFloat("PlayerPosY", -5);
        SceneManager.LoadScene("MainScene");
    }
}
