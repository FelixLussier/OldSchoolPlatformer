using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifie avec quelle boîte le joueur entre en collision
        if(gameObject.name == "PortailBleu")
        {
            
            SceneManager.LoadScene("MainScene");
        }
        if(gameObject.name == "PortailOrange")
        {
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Settings");
        }
    }

}
