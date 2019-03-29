using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bouton : PauseMenu
{

    public void changerScene()
    {
        if(gameObject.name == "BoutonSettings")
        {
            SceneManager.LoadScene("Settings");
        }
        else if (gameObject.name == "ApplySettings")
        {
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetInt("Apply", 1);
            PlayerPrefs.SetInt("Scene", 1);
        }
        else if (gameObject.name == "QuitterSettings" || gameObject.name == "CancelSettings")
        {
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetInt("Apply", 0);
            PlayerPrefs.SetInt("Scene", 1);
        }
    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}
