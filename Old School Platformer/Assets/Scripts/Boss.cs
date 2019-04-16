using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private FSM fsm;
    private FSMState standState;
    private FSMState retreatState;
    private FSMState moveTargetState;
    private FSMState runTargetState;
    private MoveTargetAction moveTargetAction;
    private MoveTargetAction runTargetAction;
    private RetreatAction retreatAction;
    private StandAction standAction;
    private List<string> finishEventStand;
    private List<string> finishEventMoveTarget;
    private List<string> finishEventRetreat;
    private List<string> finishEventRun;
    private Vector3 vecPos;
    private Vector3 vecEnnemis;
    

    void Start()
    {
        fsm = new FSM("Boss Ai");

        standState = fsm.AddState("StandState");
        moveTargetState = fsm.AddState("MoveTargetState");
        retreatState = fsm.AddState("RetreatState");
        runTargetState = fsm.AddState("RunTargetState");


        standAction = new StandAction(standState);
        moveTargetAction = new MoveTargetAction(moveTargetState);
        retreatAction = new RetreatAction(retreatState);
        runTargetAction = new MoveTargetAction(runTargetState);


        finishEventRun = new List<string>
        {
            "to move target",
            "to retreat",
            "to stand"
        };

        finishEventStand = new List<string>
        {
            "to move target",
            "to retreat",
            "to run"
           
        };

        finishEventMoveTarget = new List<string>
        {
            "to move target",
            "to stand",
            "to retreat"
            

        };
        finishEventRetreat = new List<string>
        {
            
            "to stand",
            "to run"
            

        };


        standState.AddAction(standAction);

        runTargetState.AddAction(runTargetAction);

        moveTargetState.AddAction(moveTargetAction);

        retreatState.AddAction(retreatAction);

        standState.AddTransition("to move target", moveTargetState);
        standState.AddTransition("to retreat", retreatState);
        standState.AddTransition("to run", runTargetState);

        moveTargetState.AddTransition("to move target", moveTargetState);
        moveTargetState.AddTransition("to stand", standState);
        moveTargetState.AddTransition("to retreat", retreatState);

        retreatState.AddTransition("to stand", standState);
        retreatState.AddTransition("to run", runTargetState);

        runTargetState.AddTransition("to move target", moveTargetState);
        runTargetState.AddTransition("to stand", standState);
        runTargetState.AddTransition("to retreat", retreatState);
        

        
        

        vecPos = GameObject.Find("Boss").transform.position;
        vecEnnemis = new Vector3(0.1f, 0, 0);

        moveTargetAction.init(this.transform, vecEnnemis, 2.0f, finishEventMoveTarget);
        retreatAction.init(this.transform, vecEnnemis, 0.5f, finishEventRetreat);
        runTargetAction.init(this.transform, new Vector3(0.3f, 0, 0), 1.0f,finishEventRun);
        
        standAction.init(1.0f, finishEventStand);

        fsm.Start("StandState");
    }

    
    void Update()
    {
        fsm.Update();
    }
    
}
