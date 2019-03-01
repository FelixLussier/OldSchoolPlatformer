using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouvementDuJoueur : MonoBehaviour
{

    public float masseJoueur;
    public float gravité;
    public float m_vitesse;
    public float forceDeSaut;
    private float mouvementInput;

    private Rigidbody2D myRB;
    public LayerMask playerMask;

    private bool flipTime = false;
    private bool regardeDroite = true;

    //Verifie les platformes
    public bool isGrounded;
    public Transform groundCheck, myTrans;
    public float checkRadius;
    public LayerMask whatIsGround;

    private BoxCollider2D crouchColliderDisabler;

    public UnityEvent onLandEvent;
    public class boolEvent : UnityEvent<bool> { }
    public boolEvent onCrouchEvent;
    private bool isCrouching = false;

    /*public bool isWalled;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public LayerMask whatIsWall;*/

    public bool isTop;
    public Transform topCheck;
    private bool wasTop = false;


    void Start()
    {
        m_vitesse = 100f;
        myRB = this.GetComponent<Rigidbody2D>();
        crouchColliderDisabler = this.GetComponent<BoxCollider2D>();
        myTrans = this.transform;
        groundCheck = GameObject.Find(this.name + "/GroundCheck").transform;

        if (onLandEvent == null)
            onLandEvent = new UnityEvent();
        if (onCrouchEvent == null)
            onCrouchEvent = new boolEvent();
        
    }


    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.LeftArrow)) flipTime = true;
        if (Input.GetKeyDown(KeyCode.RightArrow)) flipTime = true;
        if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCrouching = true;
            Crouch(isCrouching);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (isTop) wasTop = true;

            if (!isTop)
            {
                isCrouching = false;
                Crouch(isCrouching);
            }
        }
        if (wasTop && !isTop)
        {
            isCrouching = false;
            Crouch(isCrouching);
            wasTop = false;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, groundCheck.position, playerMask);
        isTop = Physics2D.Linecast(myTrans.position, topCheck.position, playerMask);

        myRB.rotation = 0;

        mouvementInput = Input.GetAxisRaw("Horizontal");

        Move(mouvementInput, m_vitesse);

        if (flipTime == true && mouvementInput > 0 && regardeDroite == false)
        {
            Flip();
            regardeDroite = true;
        }
        else if (flipTime == true && mouvementInput < 0 && regardeDroite == true)
        {
            Flip();
            regardeDroite = false;
        }
    }

    void Crouch(bool Crouching)
    {
        if(isGrounded)
        {
            if (Crouching)
            {
                crouchColliderDisabler.enabled = false;

                m_vitesse = 50f;
            }
            else
            {
                crouchColliderDisabler.enabled = true;
                m_vitesse = 100f;
            }
        }
    }

    void Move(float horizonalInput, float vitesse)
    {
        Vector2 mouvementVelocity = myRB.velocity;
        mouvementVelocity.x = horizonalInput * vitesse;
        myRB.velocity = mouvementVelocity;
       
    }

    void Jump()
    {
        if (isGrounded == true && !isCrouching)
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
