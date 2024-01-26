using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBase
{
    // Start is called before the first frame update
    public int groundID;
    private float movespeed=0.1f;
    public bool isActive=false;
    private bool isCloned = false;
    private float clone_place=0.0f;
    private float destroy_place = -24.0f;
    void Start()
    {
        if(!isActive)
        GroundManager.Register(this);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isActive)
            move();
    }
    void Update()
    {
        if (gameObject.transform.position.x < clone_place&&!isCloned)
        {
            isCloned = true;
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Scroll, MessageType.Scroll_NewGround, null));
        }
        if (gameObject.transform.position.x < destroy_place)
        {
            destroy();
        }
        
    }
    public void move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - movespeed, gameObject.transform.position.y);
    }
    public void clone()
    {
        GameObject newground=Instantiate(gameObject);
        newground.GetComponent<ScrollGround>().isActive = true;
        newground.tag = "ground";
    }

    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
    public override void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Scroll_NewGround && groundID == (int)message.Content)
        {
            clone();
        }
    }
}
