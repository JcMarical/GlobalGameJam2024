using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WoolballDefaultState : IState
{
    private WoolBallController manager;

    private WoolBallParameter parameter;

    private float timer;


    public WoolballDefaultState(WoolBallController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter; 
    }
    public void OnEnter()
    {


    }
    public void OnUpdate() 
    {
        if (parameter.isInteracting)
        {
            StartInteract(parameter.interactionHeight);
        }
    }
    public void OnExit() 
    {
        timer = 0;
    } 
    
    private void StartInteract(float height)
    {
        parameter.rigid.velocity = Vector2.zero;
        parameter.rigid.angularVelocity = 0;
        manager.transform.position += new Vector3(0, height, 0);
        parameter.rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        manager.TransitonState(WoolBallStateType.Upset);
    }
}
public class WoolBallUpsetState : IState
{
    private WoolBallController manager;

    private WoolBallParameter parameter;
    
    
    public WoolBallUpsetState(WoolBallController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("E001Upset");
    }
    
    public void OnUpdate()
    {
        Vector3 rotateAngle = new Vector3(0, 0, parameter.interactionRotateSpeed * Time.deltaTime);
        manager.transform.Rotate(Vector3.back);
        if (parameter.happiness > parameter.upsetThreshold && parameter.happiness < parameter.happyThreshold)
        {
            manager.TransitonState(WoolBallStateType.Happy);
        }
    }
    public void OnExit() { }
}

public class WoolBallHappyState : IState
{
    private WoolBallController manager;

    private WoolBallParameter parameter;

    private AnimatorStateInfo info;
    public WoolBallHappyState(WoolBallController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("E001Upset");
    }
    
    public void OnUpdate() 
    {
        manager.transform.Rotate(new Vector3(0,0,parameter.interactionRotateSpeed*Time.deltaTime));
        if (parameter.happiness <= parameter.upsetThreshold )
        {
            manager.TransitonState(WoolBallStateType.Upset);
        }

        if (parameter.happiness >= parameter.happyThreshold)
        {
            manager.TransitonState(WoolBallStateType.Happiest);
        }
    }
    
    public void OnExit() { }
}

public class WoolBallHappiestState : IState
{
    private WoolBallController manager;

    private WoolBallParameter parameter;

    private AnimatorStateInfo info;
    public WoolBallHappiestState(WoolBallController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("E001Upset");
    }
    
    public void OnUpdate() 
    {
        manager.transform.Rotate(new Vector3(0,0,parameter.interactionRotateSpeed*Time.deltaTime));
        if (parameter.happiness > parameter.upsetThreshold && parameter.happiness < parameter.happyThreshold)
        {
            manager.TransitonState(WoolBallStateType.Happy);
        }
    }
    
    public void OnExit() { }
}