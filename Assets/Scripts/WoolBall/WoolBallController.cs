using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WoolBallStateType
{
    Default,Upset,Happy,Happiest
}


#region 属性
[Serializable]
public class WoolBallParameter : FurnitureParameter
{
    [Header("毛球特殊属性")]
    public float throwMinSpeed;
    public float throwMaxSpeed;

    public float interactionHeight;
    public float interactionRotateSpeed;
    
}

#endregion

public class WoolBallController : FurnitureController<WoolBallParameter,WoolBallStateType>
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        parameter.animator = GetComponent<Animator>();
        states.Add(WoolBallStateType.Default,new WoolballDefaultState(this));
        states.Add(WoolBallStateType.Upset,new WoolBallUpsetState(this));
        states.Add(WoolBallStateType.Happy,new WoolBallHappyState(this));
        states.Add(WoolBallStateType.Happiest,new WoolBallHappiestState(this));
        TransitonState(WoolBallStateType.Default);
        parameter.rigid = GetComponent<Rigidbody2D>();
        parameter.rigid.velocity = Vector2.left* Random.Range(parameter.throwMinSpeed,parameter.throwMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        currentState.OnUpdate();
        if (parameter.isInteracting)
        {
            GameObject.Destroy(gameObject);
        }
        DestroyMethod(parameter.destroyDistance);
    }

    override public void ReceiveMessage(Message message)
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !parameter.isInteracting)
        {
            if (!other.GetComponentInParent<Player>().isInteracting)
            {
                if (other.transform.position.y > transform.position.y + parameter.judgeHeight)
                {
                    transform.position = new Vector3(other.transform.position.x, transform.position.y);
                    //MessageCenter.SendCustomMessage(new Message(MessageType.Type_Player, MessageType.WoolBall_Interact, null));
                    MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.WoolBall_Interact, null));
                    parameter.isInteracting = true;
                }
                else
                {
                    Debug.Log("Hit!");
                    MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_Hurt, null));
                    Destroy(gameObject.GetComponent<Collider2D>());
                }
            }
            else
            {
                Debug.Log("Hit!");
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Controll_Down, null));
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_Hurt, null));
                Destroy(gameObject.GetComponent<Collider2D>());
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
    
    #region API

    

    #endregion

}
