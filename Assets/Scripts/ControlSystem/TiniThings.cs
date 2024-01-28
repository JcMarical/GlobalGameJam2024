using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiniThings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_Hurt, null));
        }
    }
}
