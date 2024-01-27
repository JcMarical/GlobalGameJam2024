using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : ManagerBase
{
    // Start is called before the first frame update
    public static Vector3[] ScrollSpeed =new Vector3[3];
    public static Vector3 NowSpeed;
    public static float FurnitureGen_time = 5.0f;
    private float timer = 0;
    public int ProtoGroundCount;
    public int ProtoFurnitureCount;
    void Start()
    {
        ScrollSpeed[0] = new Vector3(0.1f, 0.0f, 0.0f);
        ScrollSpeed[1] = new Vector3(0.1f * Mathf.Cos(25 * Mathf.Deg2Rad), 0.1f * Mathf.Sin(25 * Mathf.Deg2Rad), 0.0f);
        NowSpeed = ScrollSpeed[0];
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
            int[] content = new int[2];
            content[0]= (int)message.Content;
            content[1] = (int)((ProtoGroundCount + 1) * Random.value);
            base.ReceiveMessage(new Message(message.Type, message.Command, content));
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
