using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 5;

    void Start()
    {
        Destroy(gameObject, time);    
    }
}
