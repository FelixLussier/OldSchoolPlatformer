using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private FSM fsm;
    private FSMState standState;
    private FSMState moveTargetState;
    private MoveTargetAction moveTargetAction;
    private StandAction standAction;
    private List<string> finishEventStand;
    private List<string> finishEventMoveTarget;
    private Vector3 vecPos;
    private Vector3 vecEnnemis;
    

    void Start()
    {
        fsm = new FSM("Boss Ai");

        standState = fsm.AddState("StandState");
        moveTargetState = fsm.AddState("MoveTargetState");


        standAction = new StandAction(standState);
        moveTargetAction = new MoveTargetAction(moveTargetState);


        finishEventStand = new List<string>
        {
            "to move target"
           
        };

        finishEventMoveTarget = new List<string>
        {
            "to move target",
            "to stand"

        };

        standState.AddAction(standAction);

        moveTargetState.AddAction(moveTargetAction);

        standState.AddTransition("to move target", moveTargetState);

        moveTargetState.AddTransition("to move target", moveTargetState);
        moveTargetState.AddTransition("to stand", standState);

        vecPos = GameObject.Find("Boss").transform.position;
        vecEnnemis = GameObject.Find("AI").transform.position;

        moveTargetAction.init(this.transform, vecPos, vecEnnemis, 2.0f, finishEventMoveTarget);
        standAction.init(1.0f, finishEventStand);

        fsm.Start("StandState");
    }

    
    void Update()
    {
        fsm.Update();
    }
}
