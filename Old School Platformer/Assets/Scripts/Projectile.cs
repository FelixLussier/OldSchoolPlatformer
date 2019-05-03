﻿using UnityEngine;

public class Projectile : Alive
{
    protected bool canBeAttacked;

    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
             rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;

        Vector2 pos;
            pos.x = 0;
            pos.y = 0;

        rigidbodyComp.position = pos;

        speed.x = 0.01F;
        speed.y = 0.01F;

        canBeAttacked = false;

        life = 1;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        actualiseMouvement();

        checkAliveCollisions();
        checkCollisions();

        if (!isAlive())
            die();
    }

    void checkAliveCollisions()
    {
        Alive[] allAlives = UnityEngine.Object.FindObjectsOfType<Alive>();

        for (int c1 = 0; c1 < allAlives.Length; c1++)
        {
            if (allAlives[c1] != this)
            {
                checkAliveCollision(allAlives[c1]);

                if (!isAlive())
                    return;
            }
        }
    }

    void checkAliveCollision(Alive obj)
    {
        if(isInCollision(this, obj))
        {
            dealDamage(obj);
        }
    }

    void dealDamage(Alive objet)
    {
        int initialLife = objet.getLife();

        objet.takeDamage(life);

        life -= initialLife;
    }

    virtual public void takeDamage(int damage) // L'objet perd de la vie.
    {
        if(canBeAttacked) 
            life -= damage;
    }

    public bool canProjectileBeAttacked()
    {
        return canBeAttacked;
    }

    public void setCanBeAttacked(bool value)
    {
        canBeAttacked = value;
    }
}
