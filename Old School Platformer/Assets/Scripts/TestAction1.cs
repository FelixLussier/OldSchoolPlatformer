using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction1 : FSMAction
{

    private string textToShow;
    private float duration;
    private float cachedDuration;
    private List<string> finishEvent;



    public TestAction1(FSMState owner) : base (owner)
    {

    }
 
    
    public void init(string textToShow, float duration,List<string> finishEvent)
    {
        this.textToShow = textToShow;
        this.duration = duration;
        this.cachedDuration = duration;
        this.finishEvent = finishEvent;
    }

    public override void OnEnter()
    {
        if(duration<=0)
        {
            Finish();
            return;
        }
        
    }

    public override void OnUpdate()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            Finish();
            return;
        }
        Debug.Log(textToShow);
    }


    public override void OnExit()
    {
        
    }


    public void Finish()
    {
       
        duration = cachedDuration;
    }


}
