using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase:MonoBase
{

    static public List<MonoBase> Monos = new List<MonoBase>();

    static public void Register(MonoBase mono)
    {
        if (!Monos.Contains(mono))
        {
            Monos.Add(mono);
        }
    }

    override public void ReceiveMessage(Message message)
    {
        if (message.Type != GetMessageType())
        {
            return;
        }
        foreach(var mono in Monos)
        {
            mono.ReceiveMessage(message);
        }
    }

    public abstract byte GetMessageType();
}
