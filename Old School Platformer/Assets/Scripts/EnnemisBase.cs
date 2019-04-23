using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisBase : MonoBehaviour
{

    private FSM fsm;
    private FSMState moveRightState;
    private FSMState moveLeftState;
    private FSMState testState3;
    private MoveAction moveLeftAction;
    private MoveAction moveRightAction;
    private List<string> finishEvent1;
    private List<string> finishEvent2;
    private List<string> finishEvent3;
    private Vector3 vecPos;
    private Vector3 vecRight;
    private Vector3 vecLeft;


    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM("Ennemis");
        moveRightState = fsm.AddState("moveRight");
        moveLeftState = fsm.AddState("moveLeft");
        testState3 = fsm.AddState("testState3");
        moveRightAction = new MoveAction(moveRightState);
        moveLeftAction = new MoveAction(moveLeftState);



        finishEvent2 = new List<string>
        {
            "To move right",
            //"To move left",

        };
        finishEvent3 = new List<string>
        {
            "To move left",
            //"To move right",

        };

        moveRightState.AddAction(moveRightAction);
        moveLeftState.AddAction(moveLeftAction);


        moveRightState.AddTransition("To move left", moveLeftState);
        moveLeftState.AddTransition("To move right", moveRightState);

        vecPos = this.transform.position;
        vecRight = new Vector3(0.05f, 0, 0);
        vecLeft = new Vector3(-0.05f, 0, 0);


        moveLeftAction.init(this.transform, vecPos, vecLeft, 1.5f, finishEvent2);
        moveRightAction.init(this.transform, vecPos, vecRight, 1.5f, finishEvent3);
        fsm.Start("moveLeft");

    }

    // Update is called once per frame
    void Update()
    {

        fsm.Update();
    }
}
