using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifie sur quelle boîte le joueur entre en collision
        if(gameObject.name == "BoxBouton2")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
