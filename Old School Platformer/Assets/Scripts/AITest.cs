using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{
    private FSM fsm;
    private FSMState testState1;
    private FSMState testState2;
    private FSMState testState3;
    private TestAction1 testAction1;
    private TestAction1 testAction2;
    private TestAction1 testAction3;



    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM("Test Ai");
        testState1 = fsm.AddState("testState1");
        testState2 = fsm.AddState("testState2");
        testState3 = fsm.AddState("testState3");
        testAction1 = new TestAction1(testState1);
        testAction2 = new TestAction1(testState2);
        testAction3 = new TestAction1(testState3);

        testState1.AddAction(testAction1);
        testState2.AddAction(testAction2);
        testState3.AddAction(testAction3);


        testState1.AddTransition("To 2", testState2);
        testState1.AddTransition("To 3", testState3);

        testState2.AddTransition("to 1", testState1);
        testState3.AddTransition("to 1", testState1);

        testAction1.init("test 1",2,0f,)


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
