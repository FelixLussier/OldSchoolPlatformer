using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityModifier = 1f;
    public float downForce;
    public float gravity;

    protected Rigidbody2D rb;
    protected Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
       
        rb.gravityScale = 1;
        rb.mass = 80f;


        float friction;
        downForce = (rb.mass * 9.81f) * Time.fixedDeltaTime;
        float forceVerticalJoueur = 200f * Time.fixedDeltaTime;

        float materialFriction = 0f;

        friction = forceVerticalJoueur * materialFriction;

        gravity = downForce - friction;

        rb.velocity += (Vector2.down * ((downForce - friction) * 0.02f));

    }

    void Mouvement(Vector2 move)
    {
        rb.position = rb.position + move;
    }
}
