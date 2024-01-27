using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : ManagerBase
{
    // Start is called before the first frame update
    public static float ScrollSpeed=0.05f;
    public static float FurnitureGen_time = 2.0f;
    private float timer = 0;
    public int ProtoGroundCount;
    public int ProtoFurnitureCount;
    void Start()
    {
        MessageCenter.Register(this);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > FurnitureGen_time)
        {
            timer = 0;
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Scroll, MessageType.Scroll_NewFurniture, null));
        }
    }
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
            int aim = (int)((ProtoGroundCount + 1) * Random.value);
            base.ReceiveMessage(new Message(message.Type, message.Command, aim));
        }
        else if (message.Command == MessageType.Scroll_NewFurniture)
        {
            int aim = (int)((ProtoFurnitureCount + 1) * Random.value);
            base.ReceiveMessage(new Message(message.Type, message.Command, aim));
        }
        else
        {
            base.ReceiveMessage(message);
        }
    }
}
