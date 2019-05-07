using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAction : FSMAction
{
    private Transform transform;
    private float duration;
    private float cachedDuration;
    
    private float polledTime;
    private List<string> finishEvent;
    private int length = 0;
    private System.Random rand = new System.Random();
    private int random;
    




    public StandAction(FSMState owner) : base(owner)
    {

    }


    public void init(float duration, List<string> finishEventList)
    {

        this.duration = duration;
        this.finishEvent = finishEventList;
        this.cachedDuration = duration;
        

    }

    public override void OnEnter()
    {
        if (duration <= 0)
        {
            Finish();
            return;
        }
        GameObject prefab = Resources.Load<GameObject>("BossBullet");

        if(GameObject.Find("Boss").GetComponent<SpriteRenderer>().flipX == true)
        {
            Vector3 bullet = new Vector3(0.3f, 0.3f, 0f);
        }
        else
        {
            Vector3 bullet = new Vector3(-0.3f, 0.3f, 0f);
        }

        

        GameObject.Instantiate(prefab, GameObject.Find("Boss").transform.position+new Vector3(0,0.3f,0), Quaternion.identity);

        
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

        
        this.polledTime = 0;
        

        duration = cachedDuration;


    }


   
}
