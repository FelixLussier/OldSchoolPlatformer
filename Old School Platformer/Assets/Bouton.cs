using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : PauseMenu
{
    public void changerScene()
    {

        if(gameObject.name == "BoutonSettings")
        {
            SceneManager.LoadScene("Settings");

        }
        else if (gameObject.name == "QuitterSettings")
        {
            SceneManager.LoadScene("MainMenu");
            pauseMenuUI.SetActive(true);
        }
    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}
