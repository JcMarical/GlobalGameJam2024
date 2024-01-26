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

    }
    public void OnExit() 
    {
        timer = 0;
    } 
}
public class WoolBallUpsetState : IState
{
    private WoolBallController manager;

    private WoolBallParameter parameter;

    private AnimatorStateInfo info;
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
        if (parameter.happiness > parameter.upsetThreshold && parameter.happiness < parameter.happyThreshold)
        {
            manager.TransitonState(WoolBallStateType.Happy);
        }
    }
    
    public void OnExit() { }
}