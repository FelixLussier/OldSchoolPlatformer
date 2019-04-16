using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisBase : MonoBehaviour
{
   
    private FSM fsm;
    private FSMState patrolStateRight;
    private FSMState patrolStateLeft;
    private PatrolAction patrolAction;
    private List<string> finishEventPatrolRight;
    private List<string> finishEventPatrolLeft;




    void Start()
    {
        fsm = new FSM("Ennemy");

        patrolStateRight = fsm.AddState("Patrol State Right");

        patrolAction = new PatrolAction(patrolStateRight);

        finishEventPatrolRight = new List<string>
        {
            "to patrol Left"
        };

        patrolStateRight.AddAction(patrolAction);

        patrolStateRight.AddTransition("to patrol Left", patrolStateLeft);

        patrolStateLeft = fsm.AddState("Patrol State Left");

        patrolAction = new PatrolAction(patrolStateLeft);

        finishEventPatrolLeft = new List<string>
        {
            "to patrol Right"
        };

        patrolStateLeft.AddAction(patrolAction);

        patrolStateLeft.AddTransition("to patrol Right", patrolStateRight);


        //patrolAction.init(8.0f, finishEventPatrol);


        fsm.Start("Patrol State");





    }

    
    void Update()
    {
        
    }
}
