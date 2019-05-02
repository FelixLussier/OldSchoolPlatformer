using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
    Tous les objects qui peuvent mourir doivent heriter de Alive.

 */

public class Alive : Collision
{
    public int life;

    void Start()
    {
        life = 1;

        rigidbodyComp = GetComponent<Rigidbody2D>();
        rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!isAlive())
            die();
    }

    virtual public void takeDamage(int damage) // L'objet perd de la vie.
    {
        life -= damage;
    }

    public void die() //! Destroy the object
    {
        Destroy(this.gameObject);
    }
    
    public bool isAlive()
    {
        return life > 0;
    }

    public int getLife()
    {
        return life;
    }
}
