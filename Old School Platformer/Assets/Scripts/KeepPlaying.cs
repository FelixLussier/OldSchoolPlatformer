using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlaying : MonoBehaviour
{

    private void Start()
    {
        if(PlayerPrefs.GetInt("Music") == 1)
        {
            Destroy(gameObject);
            PlayerPrefs.DeleteKey("Music");
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
