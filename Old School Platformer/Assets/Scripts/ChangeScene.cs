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
            PlayerPrefs.DeleteKey("Checkpoint");
            PlayerPrefs.SetFloat("PlayerPosX", -7);
            PlayerPrefs.SetFloat("PlayerPosY", -5);
            SceneManager.LoadScene("MainScene");
        }
        if(gameObject.name == "PortailOrange")
        {
            SceneManager.LoadScene("MainScene");
        }
        if(gameObject.name == "PortailBoss")
        {
            SceneManager.LoadScene("BossScene");
        }
    }

}
