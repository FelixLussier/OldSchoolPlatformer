﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MouvementDuJoueur : Gravity
{
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

    private BoxCollider2D crouchColliderDisabler;

    private UnityEvent onLandEvent;
    public class boolEvent : UnityEvent<bool> { }
    public boolEvent onCrouchEvent;
    private bool isCrouching = false;

    public bool isWalled;
    private bool isRightWalled;
    private bool isLeftWalled;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;

    private bool wallJumpAllowed = false;
    private bool hasWallJumped = false;

    public bool isTop;
    public Transform topCheck;
    private bool wasTop = false;

    public static float healthAmount;


    void Start()
    {
        healthAmount = 1;

        m_vitesse = 3f;
        forceDeSaut = 10f;
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

        if(healthAmount <= 0)
        {
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.SetFloat("PlayerPosX", -7);
            PlayerPrefs.SetFloat("PlayerPosY", -5);
            SceneManager.LoadScene("MainScene");
        }

        if (Input.GetKey(KeyCode.LeftArrow)) flipTime = true;
        if (Input.GetKey(KeyCode.RightArrow)) flipTime = true;
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
        if (isWalled)
        {
            wallJumpAllowed = true;
        }
        else wallJumpAllowed = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, groundCheck.position, playerMask);
        isTop = Physics2D.Linecast(myTrans.position, topCheck.position, playerMask);
        isRightWalled = Physics2D.Linecast(myTrans.position, wallCheckRight.position, playerMask);
        isLeftWalled = Physics2D.Linecast(myTrans.position, wallCheckLeft.position, playerMask);

        if (Physics2D.Linecast(myTrans.position, wallCheckLeft.position, playerMask) || Physics2D.Linecast(myTrans.position, wallCheckRight.position, playerMask)) isWalled = true;
        else isWalled = false;
        if (!isWalled && hasWallJumped) hasWallJumped = false;

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

        myRB.rotation = 0;
    }

    void Crouch(bool Crouching)
    {
        if(isGrounded)
        {
            if (Crouching)
            {
                crouchColliderDisabler.enabled = false;

                m_vitesse = 1.5f;
            }
            else
            {
                crouchColliderDisabler.enabled = true;
                m_vitesse = 3f;
            }
        }
    }

    void Move(float horizonalInput, float vitesse)
    {
        Vector2 mouvementVelocity = myRB.velocity;
        mouvementVelocity.x = horizonalInput * vitesse;

       /* if (isRightWalled && mouvementVelocity.x >= 0)
        {
            mouvementVelocity.x = 0;
        }
        else if (isLeftWalled && mouvementVelocity.x <= 0)
        {
            mouvementVelocity.x = 0;
        }*/
       
        myRB.velocity = mouvementVelocity;
       
    }

    void Jump()
    {
        Vector2 jumpVelocity = myRB.velocity;
        if (isGrounded && !isCrouching || wallJumpAllowed)
        {
            if (wallJumpAllowed && !hasWallJumped)
            {
                float forceWallJump = forceDeSaut;
                jumpVelocity.y = forceWallJump;
                myRB.velocity = jumpVelocity;
                hasWallJumped = true;
            } else if (isGrounded)
                jumpVelocity.y = forceDeSaut;
                myRB.velocity = jumpVelocity;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Bullet"))
        {
            healthAmount -= 0.1f;
        }
    }
}
