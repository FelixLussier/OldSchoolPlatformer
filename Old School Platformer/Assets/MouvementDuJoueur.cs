using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDuJoueur : MonoBehaviour
{

    public float masseJoueur;
    public float gravité;
    public float vitesse;
    public float forceDeSaut;
    private float mouvementInput;

    private bool jumpKeyIsPressed;
    private bool downKeyIsPressed;

    private Rigidbody2D rb;

    private bool mouvementDroite = true;

    //Verifie les platformes
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isWalled;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public LayerMask whatIsWall;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == false)
        {
            isWalled = Physics2D.OverlapCircle(wallCheckLeft.position, checkRadius, whatIsWall);
            isWalled = Physics2D.OverlapCircle(wallCheckRight.position, checkRadius, whatIsWall);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            jumpKeyIsPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded == false)
        {
            downKeyIsPressed = true;
        }

        if (mouvementDroite == false && mouvementInput > 0)
        {
            Flip();
        }
        else if (mouvementDroite == true && mouvementInput < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        mouvementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mouvementInput * vitesse, rb.velocity.y);
        rb.rotation = 0;
        gravité = -10;

        if (jumpKeyIsPressed == true)
        {
            rb.velocity = (Vector3.up * forceDeSaut);

            if (isGrounded == false)
            {
                jumpKeyIsPressed = false;
            }
        }
        if (downKeyIsPressed == true)
        {
            rb.velocity = Vector3.down * forceDeSaut;
            

            if (isGrounded == true)
            {
                downKeyIsPressed = false;
            }
        }

    }

    void Flip()
    {
        //Le joueur se mets a bouger vers la gauche
        mouvementDroite = !mouvementDroite;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
