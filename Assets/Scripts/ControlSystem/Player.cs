using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBase
{
    // Start is called before the first frame update
    private float speed = 0.1f;
    private float jumpspeed = 0.6f;
    private float jumpspeed_now=0.0f;
    private float jump_holdtime = 10.0f;
    private float jump_holdtime_now = 0.0f;
    private float a = 2.0f;
    private bool isJumping = false;

    private bool isInteracting = false;
    public GameObject wool;
    public GameObject cat;

    private float zero_x = -5.0f;
    private float offset_max = 10.0f;
    private float offset = 0.0f;

    public Collider2D BodyBox;
    public Collider2D FeetBox;
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
        if (isInteracting)
        {
            if (cat.transform.localRotation.z > 0)
            {
                cat.transform.RotateAroundLocal(Vector3.forward, speed * 0.05f);
                cat.transform.Translate(Vector3.left * 0.02f, Space.Self);
            }
            else
            {
                cat.transform.RotateAroundLocal(Vector3.back, speed * 0.05f);
                cat.transform.Translate(Vector3.right * 0.02f, Space.Self);
            }
        }
    }
    override public void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Controll_Move)
        {
            offset += speed * (float)message.Content;
            if (offset > offset_max)
            {
                offset = offset_max;
            }
            if (offset < -offset_max)
            {
                offset = -offset_max;
            }
            gameObject.transform.position = new Vector3(zero_x + offset, gameObject.transform.position.y);
            if (isInteracting)
            {
                cat.transform.RotateAroundLocal(Vector3.forward* (float)message.Content, speed*0.1f);
                cat.transform.Translate(Vector3.left * (float)message.Content*0.04f, Space.Self);
            }
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
                jumpspeed_now = jumpspeed;
                jump_holdtime_now -= Time.fixedDeltaTime;
            }
        }
        if (message.Command == MessageType.Player_OnGround)
        {
            isJumping = false;
            jumpspeed_now = 0;
        }
        if (message.Command == MessageType.WoolBall_Interact&&!isInteracting)
        {
            isInteracting = true;
            wool.SetActive(true);
            gameObject.GetComponent<Collider2D>().offset = new Vector2(gameObject.GetComponent<Collider2D>().offset.x, gameObject.GetComponent<Collider2D>().offset.y - 5.0f);
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
