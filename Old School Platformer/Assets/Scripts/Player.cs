using UnityEngine;

public class Player : Alive
{
    Projectile proj;

    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
            rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;

        speed.x = 0.00F;
        speed.y = 0.01F;

        life = 1;

        Projectile proj = Instantiate(Resources.Load("proj")) as Projectile;
    }
    void Update()
    {
    }
    
    void FixedUpdate()
    {
        actualiseMouvement();

        checkCollisions();

        if (!isAlive())
            die();
    }
}
