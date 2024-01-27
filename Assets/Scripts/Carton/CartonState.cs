
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CartonDefaultState : IState
{
    private CartonController manager;

    private CartonParameter parameter;

    private float timer;


    public CartonDefaultState(CartonController manager)
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
        parameter.fixedObject.SetActive(true);
        parameter.fixedObject.transform.position = manager.transform.position;
        manager.TransitonState(CartonStateType.UpsetFat);
    }
}
public class CartonUpsetFatState : IState
{
    private CartonController manager;

    private CartonParameter parameter;
    
    
    public CartonUpsetFatState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonUpsetFat");

    }
    
    public void OnUpdate()
    {
        if (parameter.isHurt)
        {
            parameter.isHurt = false;
            manager.TransitonState(CartonStateType.UpsetThin);
        }
    }
    public void OnExit() { }
}

public class CartonUpsetThinState : IState
{
    private CartonController manager;

    private CartonParameter parameter;
    
    
    public CartonUpsetThinState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonUpsetThin");

    }
    
    public void OnUpdate()
    {
        // Vector3 rotateAngle = new Vector3(0, 0, parameter.interactionRotateSpeed * Time.deltaTime);
        // manager.transform.Rotate(Vector3.back);
        if (parameter.happiness > parameter.upsetThreshold && parameter.happiness < parameter.happyThreshold)
        {
            manager.TransitonState(CartonStateType.NormalFat);
        }
    }
    public void OnExit() { }
}

public class CartonNormalFatState : IState
{
    private CartonController manager;

    private CartonParameter parameter;

    private AnimatorStateInfo info;
    
    public CartonNormalFatState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonNormalFat");
    }
    
    public void OnUpdate() 
    {
        if (parameter.isHurt)
        {
            parameter.isHurt = false;
            manager.TransitonState(CartonStateType.NormalThin);
        }
    }
    
    public void OnExit() { }
}

public class CartonNormalThinState : IState
{
    private CartonController manager;

    private CartonParameter parameter;

    private AnimatorStateInfo info;
    
    public CartonNormalThinState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonNormalThin");
    }
    
    public void OnUpdate() 
    {
        //   manager.transform.Rotate(new Vector3(0,0,parameter.interactionRotateSpeed*Time.deltaTime));
        if (parameter.happiness <= parameter.upsetThreshold )
        {
            manager.TransitonState(CartonStateType.NormalFat);
        }

        if (parameter.happiness >= parameter.happyThreshold)
        {
            manager.TransitonState(CartonStateType.HappyFat);
        }
    }
    
    public void OnExit() { }
}

public class CartonHappyFatState : IState
{
    private CartonController manager;

    private CartonParameter parameter;

    private AnimatorStateInfo info;
    public CartonHappyFatState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonHappyFat");
    }
    
    public void OnUpdate() 
    {
        if (parameter.isHurt)
        {
            parameter.isHurt = false;
            manager.TransitonState(CartonStateType.NormalFat);
        }
    }
    
    public void OnExit() { }
}

public class CartonHappyThinState : IState
{
    private CartonController manager;

    private CartonParameter parameter;

    private AnimatorStateInfo info;
    public CartonHappyThinState(CartonController manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("CartonHappyThin");
    }
    
    public void OnUpdate()
    {
        if ( parameter.happiness < parameter.happyThreshold)
        {
            manager.TransitonState(CartonStateType.NormalFat);
        }
    }
    
    public void OnExit() { }
}