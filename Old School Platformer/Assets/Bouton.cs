using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{
    public void changerScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
