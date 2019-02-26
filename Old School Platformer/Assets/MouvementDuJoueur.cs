using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouvementDuJoueur : MonoBehaviour
{

    public float masseJoueur;
    public float gravité;
    public float vitesse;
    public float forceDeSaut;
    private float mouvementInput;

    private bool jumpKeyIsPressed;
    private bool downKeyIsPressed;

    private Rigidbody2D myRB;
    public LayerMask playerMask;

    private bool flipTime = false;

    //Verifie les platformes
    public bool isGrounded;
    public Transform groundCheck, myTrans;
    public float checkRadius;
    public LayerMask whatIsGround;

    /*public bool isWalled;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public LayerMask whatIsWall;*/


    //public bool isTop;
    // public Transform topCheck;
    //public LayerMask whatIsTop;


    void Start()
    {
        myRB = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        groundCheck = GameObject.Find(this.name + "/GroundCheck").transform;
    }


    private void Update()
    {
       /* isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == false)
        {
            isWalled = Physics2D.OverlapCircle(wallCheckLeft.position, checkRadius, whatIsWall);
            isWalled = Physics2D.OverlapCircle(wallCheckRight.position, checkRadius, whatIsWall);

            //isTop = Physics2D.OverlapCircle(topCheck.position, checkRadius, whatIsTop);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            jumpKeyIsPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded == false)
        {
            downKeyIsPressed = true;
        }*/

        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, groundCheck.position, playerMask);

        myRB.rotation = 0;

        mouvementInput = Input.GetAxisRaw("Horizontal");

        Move(mouvementInput);

        if (flipTime == true && mouvementInput > 0)
        {
            Flip();
        }
        else if (flipTime == true && mouvementInput < 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

       /* if (downKeyIsPressed == true)
        {
            rb.velocity = Vector3.down * forceDeSaut;
            

            if (isGrounded == true)
            {
                downKeyIsPressed = false;
            }
        }*/

    }

    void Move(float horizonalInput)
    {
        Vector2 mouvementVelocity = myRB.velocity;
        mouvementVelocity.x = horizonalInput * vitesse;
        myRB.velocity = mouvementVelocity;
        flipTime = true;
    }

    void Jump()
    {
        if (isGrounded == true)
            myRB.velocity += forceDeSaut * Vector2.up;
    }

    void StartMoving(float horizonalInput)
    {
        mouvementInput = horizonalInput;
    }

    void Flip()
    {
        //Le joueur se mets a bouger vers la gauche

        flipTime = false;
        Vector3 Scaler = this.transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
