using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerBase
{
    // Start is called before the first frame update
    private float input_hor=0;
    private bool input_jump = false;
    void Start()
    {
        MessageCenter.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        input_hor = Input.GetAxisRaw("Horizontal");
        input_jump = Input.GetButton("Jump");
        if (input_jump)
        {
            MessageCenter.SendCustomMessage(new Message(GetMessageType(), MessageType.Controll_Jump,null));
        }
    }

    private void FixedUpdate()
    {
        if (input_hor != 0)
        {
            MessageCenter.SendCustomMessage(new Message(GetMessageType(), MessageType.Controll_Move, input_hor));
        }
    }

    override public byte GetMessageType()
    {
        return MessageType.Type_Controll;
    }
}
