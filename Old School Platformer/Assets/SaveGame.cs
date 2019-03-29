using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject PlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 savedPosition = new Vector2(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"));
        PlayerObject.transform.position = savedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("PlayerPosX", PlayerObject.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", PlayerObject.transform.position.y);
    }
}
