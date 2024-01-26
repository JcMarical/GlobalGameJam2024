using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : ManagerBase
{
    // Start is called before the first frame update
    public static float ScrollSpeed=0.05f;
    public int ProtoGroundCount;
    public int FurnitureCount;
    void Start()
    {
        MessageCenter.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override byte GetMessageType()
    {
        return MessageType.Type_Scroll;
    }
    public override void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Scroll_NewGround)
        {
            int aim = ((int)((ProtoGroundCount + 1) * Random.value));
            base.ReceiveMessage(new Message(message.Type, message.Command, aim));
        }
        else
        {
            base.ReceiveMessage(message);
        }
    }
}
