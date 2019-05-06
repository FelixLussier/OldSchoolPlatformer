using UnityEngine;

public class Collision : MonoBehaviour
{
    public Vector2 speed;
    public Rigidbody2D rigidbodyComp;

    public bool collLeft; //! Left side is in collision
    public bool collRight;
    public bool collTop;
    public bool collBot;

    public bool ignoreCollLeft; //! Left side is in collision
    public bool ignoreCollRight;
    public bool ignoreCollTop;
    public bool ignoreCollBot;

    void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();
        rigidbodyComp.isKinematic = true;

        GetComponent<BoxCollider2D>().isTrigger = true;

        speed.x = 0.0F;
        speed.y = 0.0F;

        collLeft = false;
        collRight = false;
        collRight = false;
        collRight = false;

        ignoreCollLeft = false;
        ignoreCollRight = false;
        ignoreCollRight = false;
        ignoreCollRight = false;
    }
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    public bool isInCollision()
    {
        return collLeft || collRight || collTop || collBot;
    }
    public bool isLeftInCollision()
    {
        return collLeft;
    }
    public bool isRightInCollision()
    {
        return collRight;
    }
    public bool isTopInCollision()
    {
        return collTop;
    }
    public bool isBotInCollision()
    {
        return collBot;
    }

    public void setIgnoreCollBot(bool value)
    {
        ignoreCollBot = value;
    }
    public void setIgnoreCollTop(bool value)
    {
        ignoreCollTop = value;
    }
    public void setIgnoreCollLeft(bool value)
    {
        ignoreCollLeft = value;
    }
    public void setIgnoreCollRight(bool value)
    {
        ignoreCollRight = value;
    }

    virtual public void actualiseMouvement()
    {
        rigidbodyComp.position += speed; // Fait avancer l'object.
    }

    public void annuleMouvementX()
    {
        Vector2 mouv;
            mouv.x = speed.x;
            mouv.y = 0;

        rigidbodyComp.position -= mouv;
    }
    public void annuleMouvementY()
    {
        Vector2 mouv;
            mouv.x = 0;
            mouv.y = speed.y;

        rigidbodyComp.position -= mouv;
    }

    public void checkCollisions()
    {
        // Reinitialise les cotes en collison

        collLeft = false;
        collRight = false;
        collTop = false;
        collBot = false;

        

        //!

        Collision[] allCollisions = UnityEngine.Object.FindObjectsOfType<Collision>();

        for (int c1 = 0; c1 < allCollisions.Length; c1++)
        {
            if (this != allCollisions[c1])
                checkSpritesCollision(this, allCollisions[c1]);
        }
    }

    static bool estLePlusgrand(float n1, float n2) //! Retourne true si n1 est le plus grand nombre (Peu importe le signe).
    {
        float nb1 = n1;
        float nb2 = n2;

        if (nb1 < 0)
            nb1 *= -1;
        if (nb2 < 0)
            nb2 *= -1;

        return nb1 > nb2;
    }

    static bool estDifferencePlusPetite(float n1, float n2, float diff)
    {
        float delta = n1 - n2;

        if (delta < 0)
            delta *= -1;

        return delta < diff;
    }

    static public bool isInCollision(Collision coll1, Collision coll2)
    {
        BoxCollider2D bColl1 = coll1.GetComponent<BoxCollider2D>();
        BoxCollider2D bColl2 = coll2.GetComponent<BoxCollider2D>();

        float top1 = bColl1.bounds.max.y;
        float top2 = bColl2.bounds.max.y;

        float bot1 = bColl1.bounds.min.y;
        float bot2 = bColl2.bounds.min.y;

        float left1 = bColl1.bounds.min.x;
        float left2 = bColl2.bounds.min.x;

        float right1 = bColl1.bounds.max.x;
        float right2 = bColl2.bounds.max.x;


        if ((top1 <= bot2)
           || (bot1 >= top2)
           || (right1 <= left2)
           || (left1 >= right2))
            return false; // Pas en collision
        else
            return true;
    }

    static public bool checkSpritesCollision(Collision coll1, Collision coll2)
    {
        BoxCollider2D bColl1 = coll1.GetComponent<BoxCollider2D>();
        BoxCollider2D bColl2 = coll2.GetComponent<BoxCollider2D>();

        float top1 = bColl1.bounds.max.y;
        float top2 = bColl2.bounds.max.y;

        float bot1 = bColl1.bounds.min.y;
        float bot2 = bColl2.bounds.min.y;

        float left1 = bColl1.bounds.min.x;
        float left2 = bColl2.bounds.min.x;

        float right1 = bColl1.bounds.max.x;
        float right2 = bColl2.bounds.max.x;


        if ((top1 <= bot2)
           || (bot1 >= top2)
           || (right1 <= left2)
           || (left1 >= right2))
            return false; // Pas en collision

        // On sait que les deux objects sont en collision
        // On fait donc davantage de tests pour connaitre la nature de la collision

        Vector2 coll1VersColl2 =  coll2.rigidbodyComp.position - coll1.rigidbodyComp.position;

        //

        Vector2 pos = coll1.rigidbodyComp.position;

        // Est-ce deux sommets qui sont en collision ?

        if (estDifferencePlusPetite(coll1VersColl2.x, coll1VersColl2.y, 0.05F))
        {
            if (coll1VersColl2.y < 0 && coll1VersColl2.x < 0)
            {
                //! On repositionne Coll1 pour qu'il touche a coll2 sans etre dedans.

                pos.x = right2 + bColl1.bounds.extents.x;
                pos.y = top2 + bColl1.bounds.extents.y;


                coll1.rigidbodyComp.position = pos;

                //

                coll1.collBot = true;
                coll1.collLeft = true;

                coll2.collTop = true;
                coll2.collRight = true;

                return true;
            }
            else if (coll1VersColl2.y < 0 && coll1VersColl2.x < 0)
            {
                //! On repositionne Coll1 pour qu'il touche a coll2 sans etre dedans.

                pos.x = right2 + bColl1.bounds.extents.x;
                pos.y = bot2 - bColl1.bounds.extents.y;


                coll1.rigidbodyComp.position = pos;

                //

                coll1.collTop = true;
                coll1.collLeft = true;

                coll2.collBot = true;
                coll2.collRight = true;

                return true;
            }
            else if (coll1VersColl2.y > 0 && coll1VersColl2.x > 0)
            {
                //! On repositionne Coll1 pour qu'il touche a coll2 sans etre dedans.

                pos.x = left2 - bColl1.bounds.extents.x;
                pos.y = bot2 - bColl1.bounds.extents.y;


                coll1.rigidbodyComp.position = pos;

                //

                coll1.collTop = true;
                coll1.collRight = true;

                coll2.collBot = true;
                coll2.collLeft = true;

                return true;
            }
            else if (coll1VersColl2.y < 0 && coll1VersColl2.x > 0)
            {
                //! On repositionne Coll1 pour qu'il touche a coll2 sans etre dedans.

                pos.x = left2 - bColl1.bounds.extents.x;
                pos.y = top2 + bColl1.bounds.extents.y;


                coll1.rigidbodyComp.position = pos;

                //

                coll1.collBot = true;
                coll1.collRight = true;

                coll2.collTop = true;
                coll2.collLeft = true;

                return true;
            }
        }


        // Si on en arrive ici, c'est que ce n'est pas une collison sommet-sommet,
        // C'est donc une collision coté-coté

        // On vérifie quel coté est en collision.

        if (estLePlusgrand(coll1VersColl2.y, coll1VersColl2.x)) 
        {
            if(coll1VersColl2.y < 0 && !coll1.ignoreCollBot)
            {
                //! On position ne les cotes pour qu'ils se touchent (Pour ne pas qu'un des sprites soit dans l'autre)

                pos.y = top2 + bColl1.bounds.extents.y;
                coll1.rigidbodyComp.position = pos;

                //!

                coll1.collBot = true;
                coll2.collTop = true;
            }
            else if(!coll1.ignoreCollTop)
            {
                pos.y = bot2 - bColl1.bounds.extents.y;
                coll1.rigidbodyComp.position = pos;

                //!

                coll1.collTop = true;
                coll2.collBot = true;
            }
        }
        else 
        {
            if (coll1VersColl2.x < 0 && !coll1.ignoreCollLeft)
            {
                //! On position ne les cotes pour qu'ils se touchent (Pour ne pas qu'un des sprites soit dans l'autre)

                pos.x = right2 + bColl1.bounds.extents.x;
                coll1.rigidbodyComp.position = pos;

                //!

                coll1.collLeft = true;
                coll2.collRight = true;
            }
            else if(!coll1.ignoreCollRight)
            {
                //! On position ne les cotes pour qu'ils se touchent (Pour ne pas qu'un des sprites soit dans l'autre)

                pos.x = left2 - bColl1.bounds.extents.x;
                coll1.rigidbodyComp.position = pos;

                //!

                coll1.collRight = true;
                coll2.collLeft = true;
            }
        }

        return true;
    }

    //------------------------------

    public Vector2 getSpeed()
    {
        return speed;
    }
    public float getSpeedX()
    {
        return speed.x;
    }
    public float getSpeedY()
    {
        return speed.y;
    }

    virtual public void setSpeed(Vector2 valeur)
    {
        speed = valeur;
    }
    virtual public void setSpeed(float speedX, float speedY)
    {
        speed.x = speedX;
        speed.y = speedY;
    }
    virtual public void setSpeedX(float speedX)
    {
        speed.x = speedX;
    }
    virtual public void setSpeedY(float speedY)
    {
        speed.y = speedY;
    }

    public void setPos(Vector2 pos)
    {
        rigidbodyComp.position = pos;
    }
    public void setPosX(float posX)
    {
        Vector2 pos;
            pos.x = posX;
            pos.y = rigidbodyComp.position.y;

        rigidbodyComp.position = pos;
    }
    public void setPosY(float posY)
    {
        Vector2 pos;
        pos.x = rigidbodyComp.position.y;
        pos.y = posY;

        rigidbodyComp.position = pos;
    }

    public Vector2 getPos()
    {
       return rigidbodyComp.position;
    }
}
