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
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetInt("Scene", 1);
            Destroy(music);
        }
        else if (gameObject.name == "QuitterSettings")
        {
            string nomScene = PlayerPrefs.GetString("SceneName");
            SceneManager.LoadScene(nomScene);
            PlayerPrefs.SetInt("Scene", 1);
            PlayerPrefs.DeleteKey("SceneName");
        }
    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}
