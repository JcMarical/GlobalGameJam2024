using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : ManagerBase
{
    // Start is called before the first frame update
    public int ProtoGroundCount;
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
        int aim=((int)((ProtoGroundCount+1) * Random.value));
        Debug.Log(aim);
        base.ReceiveMessage(new Message(message.Type, message.Command, aim));
    }
}
