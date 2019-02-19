using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState 
{
    private readonly string name;
    private readonly FSM owner;
    private List<FSMAction> actions;
    private readonly Dictionary<string, FSMState> transitionMap;

    public FSMState(string name, FSM owner)
    {
        this.name = name;
        this.owner = owner;
        this.transitionMap = new Dictionary<string, FSMState>();
        this.actions = new List<FSMAction>();
    }


    public void AddTransition(string id, FSMState destinationState)
    {
        if(transitionMap.ContainsKey(id))
        {
            Debug.LogError(string.Format("State {0} already contains transition for {1}", this.name, id));
            return;
        }

        transitionMap[id] = destinationState;    
    }


    /*public FSMState GetTransition(string eventId)
    {
       
    }*/

    public void AddAction(FSMAction action)
    {

    }

    public IEnumerable<FSMAction> GetActions()
    {
        return actions;
    }

    public void SendEvent(string eventid)
    {

    }
}
