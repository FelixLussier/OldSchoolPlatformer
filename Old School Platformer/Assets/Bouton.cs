using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{
    public void changerScene()
    {
        if(gameObject.name == "OuvrirSettings")
        {
            SceneManager.LoadScene("SettingsScene");
        }
        else if (gameObject.name == "QuitterSettings")
        {
            SceneManager.LoadScene("MainUI");
        }
    }
}
