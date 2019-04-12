using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton : MonoBehaviour
{

    public GameObject music;

    public void changerScene()
    {

        music = GameObject.Find("Music");

        if(gameObject.name == "BoutonSettings")
        {
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Settings");
        }
        else if(gameObject.name == "BoutonMainMenu")
        {
            PlayerPrefs.SetInt("Scene", 1);
            PlayerPrefs.SetInt("Music", 1);
            SceneManager.LoadScene("MainMenu");
        }
        else if (gameObject.name == "QuitterSettings")
        {
            PlayerPrefs.SetInt("Scene", 1);
            string nomScene = PlayerPrefs.GetString("SceneName");
            SceneManager.LoadScene(nomScene);
            PlayerPrefs.DeleteKey("SceneName");
        }
    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}
