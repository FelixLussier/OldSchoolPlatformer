using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private FSM fsm;
    private FSMState standState;
    private FSMState retreatState;
    private FSMState moveTargetState;
    private MoveTargetAction moveTargetAction;
    private RetreatAction retreatAction;
    private StandAction standAction;
    private List<string> finishEventStand;
    private List<string> finishEventMoveTarget;
    private List<string> finishEventRetreat;
    private Vector3 vecPos;
    private Vector3 vecEnnemis;
    

    void Start()
    {
        fsm = new FSM("Boss Ai");

        standState = fsm.AddState("StandState");
        moveTargetState = fsm.AddState("MoveTargetState");
        retreatState = fsm.AddState("RetreatState");


        standAction = new StandAction(standState);
        moveTargetAction = new MoveTargetAction(moveTargetState);
        retreatAction = new RetreatAction(retreatState);


        finishEventStand = new List<string>
        {
            "to move target",
            "to retreat"
           
        };

        finishEventMoveTarget = new List<string>
        {
            "to move target",
            "to stand",
            "to retreat"
            

        };
        finishEventRetreat = new List<string>
        {
            
            "to stand"
            

        };


        standState.AddAction(standAction);

        moveTargetState.AddAction(moveTargetAction);

        retreatState.AddAction(retreatAction);

        standState.AddTransition("to move target", moveTargetState);
        standState.AddTransition("to retreat", retreatState);

        moveTargetState.AddTransition("to move target", moveTargetState);
        moveTargetState.AddTransition("to stand", standState);
        moveTargetState.AddTransition("to retreat", retreatState);

        retreatState.AddTransition("to stand", standState);
        

        
        

        vecPos = GameObject.Find("Boss").transform.position;
        vecEnnemis = new Vector3(0.1f, 0, 0);

        moveTargetAction.init(this.transform, vecEnnemis, 2.0f, finishEventMoveTarget);
        retreatAction.init(this.transform, vecEnnemis, 0.5f, finishEventRetreat);
        
        standAction.init(1.0f, finishEventStand);

        fsm.Start("StandState");
    }

    
    void Update()
    {
        fsm.Update();
    }
    
}
