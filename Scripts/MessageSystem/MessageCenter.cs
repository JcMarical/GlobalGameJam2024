using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter
{
   static public List<ManagerBase> Managers=new List<ManagerBase>();

    static public void Register(ManagerBase manager)
    {
        if (!Managers.Contains(manager))
        {
            Managers.Add(manager);
        }
    }

    static public void SendCustomMessage(Message message)
    {
        foreach(var manager in Managers)
        {
            manager.ReceiveMessage(message);
        }
    }
}
