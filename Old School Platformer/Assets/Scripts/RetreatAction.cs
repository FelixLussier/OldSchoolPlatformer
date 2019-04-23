using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatAction : FSMAction
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





    public RetreatAction(FSMState owner) : base(owner)
    {

    }


    public void init(Transform transform,Vector3 deplacement,float duration, List<string> finishEventList)
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
        if (GameObject.Find("Boss").transform.position.x < GameObject.Find("AI").transform.position.x)
        {
            GameObject.Find("Boss").GetComponent<SpriteRenderer>().flipX = false;
            this.positionTo = this.positionFrom - deplacement;
        }
        else
        {
            GameObject.Find("Boss").GetComponent<SpriteRenderer>().flipX = true;
            this.positionTo = this.positionFrom + deplacement;
            
        }

        SetPosition(Vector3.Lerp(this.positionFrom, this.positionTo, Mathf.Clamp(polledTime / cachedDuration, 0, 1)));

    }


    public override void OnExit()
    {

    }


    public void Finish()
    {



        this.length = this.finishEvent.Count;


        random = this.rand.Next(0, length);


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
