using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
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
            PlayerPrefs.SetInt("Scene", 1);
        }
    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}
