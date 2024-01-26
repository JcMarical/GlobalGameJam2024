using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : ScrollMono
{
    public int groundID;
    private bool isCloned = false;
    public float clone_place = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < clone_place && !isCloned)
        {
            isCloned = true;
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Scroll, MessageType.Scroll_NewGround, null));
        }
        if (gameObject.transform.position.x < destroy_place)
        {
            destroy();
        }
    }
    public override void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Scroll_NewGround && groundID == (int)message.Content)
        {
            clone();
        }
    }
}
