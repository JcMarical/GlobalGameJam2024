using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public byte Type;
    public int Command;
    public object Content;
    public Message(byte Type,int Command,object Content)
    {
        this.Type = Type;
        this.Command = Command;
        this.Content = Content;
    }
}
