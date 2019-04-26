using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathPit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            PlayerPrefs.SetFloat("PlayerPosX", 18);
            PlayerPrefs.SetFloat("PlayerPosY", -3);
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            PlayerPrefs.SetFloat("PlayerPosX", -7);
            PlayerPrefs.SetFloat("PlayerPosY", -5);
            SceneManager.LoadScene("MainScene");
        }
    }
}
