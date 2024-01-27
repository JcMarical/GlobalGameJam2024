using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController<T1,T2> : MonoBehaviour 
    where T1 : class
    where T2 : Enum
{
    public T1 parameter;

    protected IState currentState;

    protected Dictionary<T2, IState> states = new Dictionary<T2, IState>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TransitonState(T2 type)
    {
        if (currentState! != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }
    
    public virtual void StartInteract(float height)
    {

    }
}
