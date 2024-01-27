using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum CartonStateType
{
    Default,UpsetFat,UpsetThin,NormalFat,NormalThin,HappyFat,HappyThin
}


#region 属性
[Serializable]
public class CartonParameter : FurnitureParameter
{
    [Header("毛球特殊属性")]
    public float throwMinSpeed;
    public float throwMaxSpeed;
    
    public float interactionHeight;
    public float interactionRotateSpeed;

    public bool isHurt;
}

#endregion

public class CartonController : FurnitureController<CartonParameter,CartonStateType>
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        parameter.animator = GetComponent<Animator>();
        states.Add(CartonStateType.Default,new CartonDefaultState(this));
        states.Add(CartonStateType.UpsetFat,new CartonUpsetFatState(this));
        states.Add(CartonStateType.UpsetThin,new CartonUpsetThinState(this));
        states.Add(CartonStateType.NormalFat,new CartonNormalFatState(this));
        states.Add(CartonStateType.NormalThin,new CartonNormalThinState(this));
        states.Add(CartonStateType.HappyFat,new CartonHappyFatState(this));
        states.Add(CartonStateType.HappyThin,new CartonHappyThinState(this));
        
        TransitonState(CartonStateType.Default);
        parameter.rigid = GetComponent<Rigidbody2D>();
        //初速度
        parameter.rigid.velocity = Vector2.left* Random.Range(parameter.throwMinSpeed,parameter.throwMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
        DestroyMethod(parameter.destroyDistance);
        InteractRotation(parameter.destroyDistance);
    }

    override public void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Carton_Hurt)
        {
            parameter.isHurt = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            if (other.transform.position.y > transform.position.y + parameter.judgeHeight)
            {
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Player, MessageType.Carton_Interact, null));
                parameter.isInteracting = true;
            }
            else
            {   
                Debug.Log("Hit!");
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Player, MessageType.Player_Hurt, null));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void InteractRotation(float rotateSpeed)
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    #region API

    

    #endregion

}
