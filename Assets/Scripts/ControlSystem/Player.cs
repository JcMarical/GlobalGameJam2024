using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBase
{
    // Start is called before the first frame update
    private float speed = 0.1f;
    private float jumpspeed = 0.5f;
    private float jumpspeed_now=0.0f;
    private float jump_holdtime = 5.0f;
    private float jump_holdtime_now = 0.0f;
    private float a = 2.0f;
    private bool isJumping = false;
    void Start()
    {
        InputManager.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (isJumping)
        {
            jumpspeed_now -= a*Time.fixedDeltaTime;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + jumpspeed_now);
        }
    }
    override public void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Controll_Move)
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed*(float)message.Content, gameObject.transform.position.y);
        }
        if (message.Command == MessageType.Controll_Jump)
        {
            if (!isJumping)
            {
                isJumping = true;
                jumpspeed_now = jumpspeed;
                jump_holdtime_now = jump_holdtime;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + jumpspeed_now);
            }
            else if(jump_holdtime_now>0)
            {
                Debug.Log("done");
                jumpspeed_now = jumpspeed;
                jump_holdtime_now -= Time.fixedDeltaTime;
            }
        }
        if (message.Command == MessageType.Player_OnGround)
        {
            isJumping = false;
            jumpspeed_now = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_OnGround, null));
        }
    }
}
