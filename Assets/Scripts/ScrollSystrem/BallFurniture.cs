using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFurniture : ScrollMono
{
    // Start is called before the first frame update
    public int FurnitureID;
    private float BoundSpeed=0.5f;
    private float BoundSpeed_now=0.0f;
    private float a=1.5f;
    void Start()
    {
        behavior_start();
    }

    private void FixedUpdate()
    {
        behavior_fixed();
    }

    public override void behavior_start()
    {
        base.behavior_start();
    }
    public override void behavior_fixed()
    {
        base.behavior_fixed();
    }

    public override void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Scroll_NewFurniture && FurnitureID == (int)message.Content)
        {
            clone();
        }
    }
    public override GameObject clone()
    {
        GameObject NewFurniture=base.clone();
        NewFurniture.transform.position = NewFurniture.transform.position + Vector3.down;
        return NewFurniture;
    }
}
