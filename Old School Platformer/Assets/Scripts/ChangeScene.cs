using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifie avec quelle boîte le joueur entre en collision
        if(gameObject.name == "PortailBleu")
        {
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.SetFloat("PlayerPosX", 5);
            PlayerPrefs.SetFloat("PlayerPosY", 4);
            SceneManager.LoadScene("MainScene");
        }
        if(gameObject.name == "PortailOrange")
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}
