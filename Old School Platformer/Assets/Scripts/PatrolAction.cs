using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : FSMAction
{
    private Transform transform;
    private float duration;
    private float cachedDuration;
    private float journeyLength;
    private float polledTime;
    private List<string> finishEvent;
    private int length = 0;
    private System.Random rand = new System.Random();
    private int random;
    private Vector3 positionFrom;
    private Vector3 positionTo;
    private Vector3 positionToW;




    public PatrolAction(FSMState owner) : base(owner)
    {

    }


    public void init(Transform transform, float duration, List<string> finishEventList)
    {

        this.duration = duration;
        this.finishEvent = finishEventList;
        this.cachedDuration = duration;
        this.transform = transform;
        
        this.polledTime = 0;
        this.journeyLength = Vector3.Distance(this.positionFrom, this.positionTo);

    }

    public override void OnEnter()
    {
        if (duration <= 0)
        {
            Finish();
            return;
        }
        SetPosition(this.positionFrom);
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

        if (random == 0)
        {
            Finish();

            return;
        }


        this.positionFrom = GameObject.Find("AI").transform.position;
        this.positionTo = this.positionFrom + this.positionToW;

        //transform.position = Vector3.MoveTowards(this.positionFrom, this.positionTo, 0.005f*Time.deltaTime);
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

        //SetPosition(this.positionFrom + this.positionToW);
        SetPosition(Vector3.Lerp(this.positionFrom, this.positionTo, Mathf.Clamp(polledTime / cachedDuration, 0, 2)));
        this.polledTime = 0;
        this.journeyLength = Vector3.Distance(this.positionFrom, this.positionTo);

        duration = cachedDuration;


    }


    private void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

}
