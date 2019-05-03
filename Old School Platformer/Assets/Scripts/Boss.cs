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
    private FSMState jumpState;
    private MoveTargetAction moveTargetAction;
    private MoveTargetAction runTargetAction;
    private RetreatAction retreatAction;
    private StandAction standAction;
    private JumpAction jumpAction;
    private List<string> finishEventStand;
    private List<string> finishEventMoveTarget;
    private List<string> finishEventRetreat;
    private List<string> finishEventRun;
    private List<string> finishEventJump;
    private Vector3 vecPos;
    private Vector3 vecEnnemis;
    private Vector3 vecJump;
    

    void Start()
    {
        fsm = new FSM("Boss Ai");

        standState = fsm.AddState("StandState");
        moveTargetState = fsm.AddState("MoveTargetState");
        retreatState = fsm.AddState("RetreatState");
        runTargetState = fsm.AddState("RunTargetState");
        jumpState = fsm.AddState("JumpState");


        standAction = new StandAction(standState);
        moveTargetAction = new MoveTargetAction(moveTargetState);
        retreatAction = new RetreatAction(retreatState);
        runTargetAction = new MoveTargetAction(runTargetState);
        jumpAction = new JumpAction(jumpState);


        finishEventRun = new List<string>
        {
            "to move target",
            "to retreat",
            "to stand",
            "to jump"
        };

        finishEventStand = new List<string>
        {
            "to move target",
            "to retreat",
            "to run",
            "to jump"
           
        };

        finishEventMoveTarget = new List<string>
        {
            "to move target",
            "to stand",
            "to retreat",
            "to jump"
            

        };
        finishEventRetreat = new List<string>
        {
            
            "to stand",
            "to run"
            

        };
        finishEventJump = new List<string>
        {
            "to stand"
        };


        standState.AddAction(standAction);

        runTargetState.AddAction(runTargetAction);

        moveTargetState.AddAction(moveTargetAction);

        retreatState.AddAction(retreatAction);

        jumpState.AddAction(jumpAction);

        standState.AddTransition("to move target", moveTargetState);
        standState.AddTransition("to retreat", retreatState);
        standState.AddTransition("to run", runTargetState);
        standState.AddTransition("to jump", jumpState);

        moveTargetState.AddTransition("to move target", moveTargetState);
        moveTargetState.AddTransition("to stand", standState);
        moveTargetState.AddTransition("to retreat", retreatState);
        moveTargetState.AddTransition("to jump", jumpState);

        retreatState.AddTransition("to stand", standState);
        retreatState.AddTransition("to run", runTargetState);

        runTargetState.AddTransition("to move target", moveTargetState);
        runTargetState.AddTransition("to stand", standState);
        runTargetState.AddTransition("to retreat", retreatState);
        runTargetState.AddTransition("to jump", jumpState);

        jumpState.AddTransition("to stand", standState);
        
        

        vecPos = GameObject.Find("Boss").transform.position;
        vecEnnemis = new Vector3(0.1f, 0, 0);
        vecJump = new Vector3(0f, 0.15f, 0);


        moveTargetAction.init(this.transform, vecEnnemis, 2.0f, finishEventMoveTarget);
        retreatAction.init(this.transform, vecEnnemis, 0.5f, finishEventRetreat);
        runTargetAction.init(this.transform, new Vector3(0.3f, 0, 0), 1.0f,finishEventRun);
        jumpAction.init(this.transform, vecJump, 2f, finishEventJump);
        
        standAction.init(1.0f, finishEventStand);

        fsm.Start("StandState");
    }

    
    void Update()
    {
        fsm.Update();
    }
    
}
