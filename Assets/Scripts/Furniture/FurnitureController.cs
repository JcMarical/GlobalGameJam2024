using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController<T1,T2> : MonoBase
    where T1 : FurnitureParameter
    where T2 : Enum
{
    public T1 parameter;

    protected IState currentState;

    protected Dictionary<T2, IState> states = new Dictionary<T2, IState>();
    // Start is called before the first frame update
    protected virtual void Start()
    {
        InputManager.Register(this);
    }
    
    

    // Update is called once per frame

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
    
    protected void DestroyMethod(float distance)
    {
        if(transform.position.x < distance)
            GameObject.Destroy(this.gameObject);
    }

}
