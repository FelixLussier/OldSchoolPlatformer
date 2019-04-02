using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouvementDuJoueur : MonoBehaviour
{

    public float masseJoueur = 1;
    public const float CONST_GRAVITY = 4;
    public float materialFriction;
    public float downForce;
    private float forceVerticalJoueur;

    public float m_vitesse;
    public float forceDeSaut;
    private float mouvementInput;

    private Rigidbody2D myRB;
    private float friction;
    public LayerMask playerMask;

    private bool flipTime = false;
    private bool regardeDroite = true;

    //Verifie les platformes
    public bool isGrounded;
    public Transform groundCheck, myTrans;
    public float checkRadius;

    private BoxCollider2D crouchColliderDisabler;

   /* private BoxCollider2D squareSlick;
    private CircleCollider2D circleSlick;*/

    public UnityEvent onLandEvent;
    public class boolEvent : UnityEvent<bool> { }
    public boolEvent onCrouchEvent;
    private bool isCrouching = false;

    public bool isWalled;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;

    private bool wallJumpAllowed = false;
    private bool hasWallJumped = false;

    public bool isTop;
    public Transform topCheck;
    private bool wasTop = false;


    void Start()
    {
        m_vitesse = 3f;
        forceDeSaut = 10f;
        myRB = this.GetComponent<Rigidbody2D>();
        crouchColliderDisabler = this.GetComponent<BoxCollider2D>();

        /*squareSlick = this.GetComponent<BoxCollider2D>();
        squareSlick.friction.Equals(0);
        circleSlick = this.GetComponent<CircleCollider2D>();
        circleSlick.friction.Equals(0);*/

        myTrans = this.transform;
        groundCheck = GameObject.Find(this.name + "/GroundCheck").transform;


        if (onLandEvent == null)
            onLandEvent = new UnityEvent();
        if (onCrouchEvent == null)
            onCrouchEvent = new boolEvent();
    }


    private void Update()
    {

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
        if (isWalled) wallJumpAllowed = true;
        else wallJumpAllowed = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, groundCheck.position, playerMask);
        isTop = Physics2D.Linecast(myTrans.position, topCheck.position, playerMask);
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

       
        //myRB.gravityScale = (9.81f / 50f) * CONST_GRAVITY;
       /* myRB.gravityScale = 1;
        friction = 9.81f / 500f;
        masseJoueur = 80f;

        float downForceTemp = Vector2.down.y;
        float forceVerticalTemp = 0f;
        downForce = (masseJoueur * 9.81f) / 50f;
        forceVerticalJoueur = 1f / 50f;

        if (isWalled)
        {
            //myRB.gravityScale -= friction;
            // myRB.gravityScale /= (9.81f * CONST_GRAVITY) - (materialFriction * downForce) / 50f;
            //myRB.velocity /= 1.1f;

            materialFriction = 0.5f;

            if (downForceTemp < downForce && forceVerticalTemp < forceVerticalJoueur)
            {
                downForceTemp += (downForce * Time.fixedDeltaTime);
                forceVerticalTemp += (forceVerticalJoueur * Time.fixedDeltaTime);

                myRB.velocity += (Vector2.down * (downForceTemp)) + (Vector2.up * (forceVerticalTemp * materialFriction));
            }

        }
        else
        {
            if (downForceTemp < downForce)
            {
                downForceTemp += (downForce * Time.fixedDeltaTime);

                myRB.velocity += (Vector2.down * (downForceTemp));
            }
        }
        */

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
        myRB.velocity = mouvementVelocity;
       
    }

    void Jump()
    {
        if (isGrounded && !isCrouching || wallJumpAllowed)
        {
            if (wallJumpAllowed && !hasWallJumped)
            {
                float forceWallJump = forceDeSaut;
                myRB.velocity = forceWallJump * Vector2.up;
                hasWallJumped = true;
            } else if (isGrounded)
                myRB.velocity += forceDeSaut * Vector2.up;
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
}
