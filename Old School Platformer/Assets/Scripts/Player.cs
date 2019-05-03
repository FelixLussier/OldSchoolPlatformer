using UnityEngine;

public class Player : Alive
{
    GameObject proj;

    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
            rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;

        speed.x = 0.00F;
        speed.y = 0.01F;

        life = 1;

        proj = Instantiate(Resources.Load("proj"), new Vector3(0F,1.0F,0F), Quaternion.identity) as GameObject;


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
