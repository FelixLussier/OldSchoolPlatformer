﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticObject : Collision
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
            rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
