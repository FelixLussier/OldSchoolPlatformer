using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetAction : FSMAction
{
    private Transform transform;
    private float duration;
    private float cachedDuration;
    private Vector3 positionFrom;
    private Vector3 positionTo;
    private Vector3 deplacement;
    private float polledTime;
    private List<string> finishEvent;
    private int length = 0;
    private System.Random rand = new System.Random();
    private int random;





    public MoveTargetAction(FSMState owner) : base(owner)
    {

    }


    public void init(Transform transform, Vector3 deplacement, float duration, List<string> finishEventList)
    {

        this.duration = duration;
        this.finishEvent = finishEventList;
        this.cachedDuration = duration;
        this.deplacement = deplacement;


    }

    public override void OnEnter()
    {
        if (duration <= 0)
        {
            Finish();
            return;
        }
        GameObject prefab = Resources.Load<GameObject>("BossBullet");

        GameObject.Instantiate(prefab, GameObject.Find("Boss").transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);

    }

    public override void OnUpdate()
    {
        polledTime += Time.deltaTime;
        duration -= Time.deltaTime;
        random = this.rand.Next(0, 13);

        if (duration <= 0)
        {

            Finish();
            return;
        }

        this.positionFrom = GameObject.Find("Boss").transform.position;
        //this if/else finds out on which side the ennemis is
        if (GameObject.Find("Boss").transform.position.x < GameObject.Find("Joueur").transform.position.x)
        {
            GameObject.Find("Boss").GetComponent<SpriteRenderer>().flipX = true;
            this.positionTo = this.positionFrom + deplacement;
        }
        else
        {
            GameObject.Find("Boss").GetComponent<SpriteRenderer>().flipX = false;
            this.positionTo = this.positionFrom - deplacement;
        }
        

        //Makes sure the boss doesn't move in too close
        if (GameObject.Find("Boss").transform.position.x - GameObject.Find("Joueur").transform.position.x > 2 || GameObject.Find("Boss").transform.position.x - GameObject.Find("Joueur").transform.position.x < -2)
        {
            SetPosition(Vector3.Lerp(this.positionFrom, this.positionTo, Mathf.Clamp(polledTime / cachedDuration, 0, 1)));
        }

    }


    public override void OnExit()
    {

    }


    public void Finish()
    {



        this.length = this.finishEvent.Count;

        //Chooses a random transition to another state
        random = this.rand.Next(0, length);

        //Returns the next state to go to
        if (!string.IsNullOrEmpty(this.finishEvent[random]))
            GetOwner().SendEvent(this.finishEvent[random]);

        SetPosition(Vector3.Lerp(this.positionFrom, this.positionTo, Mathf.Clamp(polledTime / cachedDuration, 0, 1)));
        this.polledTime = 0;


        duration = cachedDuration;


    }
    private void SetPosition(Vector3 position)
    {
        GameObject.Find("Boss").transform.position = position;
    }
}
