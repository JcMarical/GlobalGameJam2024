using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFurniture : ScrollMono
{
    // Start is called before the first frame update
    public int FurnitureID;
    public float height_dis;
    public float check_dis;
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
        if (!isActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position+Vector3.down* check_dis, Vector2.down, 100.0f);
            if (hit.collider.tag == "ground")
            {
                if(hit.distance < height_dis)
                {
                    gameObject.transform.position += new Vector3(0.0f, height_dis - hit.distance, 0.0f);
                }
                else if (hit.distance > height_dis+4.0f)
                {
                    gameObject.transform.position -= new Vector3(0.0f,hit.distance-(height_dis+4.0f), 0.0f);
                }
            }
        }

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
