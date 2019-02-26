using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction1 : FSMAction
{

    private string textToShow;
    private float duration;
    private float cachedDuration;
    private List<string> finishEvent;
    private int length= 0;
    private System.Random rand = new System.Random();
    private int random;




    public TestAction1(FSMState owner) : base (owner)
    {

    }
 
    
    public void init(string textToShow, float duration,List<string> finishEvent1)
    {
        this.textToShow = textToShow;
        this.duration = duration;
        this.finishEvent = finishEvent1;
        this.cachedDuration = duration;
        


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
        
        
        
        this.length = this.finishEvent.Count;
        

        random = this.rand.Next(0, length);
        //random -= 1;

        if(!string.IsNullOrEmpty(this.finishEvent[random]))
        GetOwner().SendEvent(this.finishEvent[random]);



        duration = cachedDuration;


    }


}
