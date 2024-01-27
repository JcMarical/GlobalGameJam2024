using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : ScrollMono
{
    public int groundID;
    private bool isCloned = false;
    private bool isChecked = false;
    public float clone_place = 0.0f;
    public float check_place = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < check_place)
        {
            if (!isChecked)
            {
                isChecked = true;
                if(groundID==0)
                {
                    ScrollManager.NowSpeed = ScrollManager.ScrollSpeed[0];
                }
                if (groundID == 1)
                {
                    Debug.Log("done");
                    ScrollManager.NowSpeed = ScrollManager.ScrollSpeed[1];
                }
            }

        }
        if (gameObject.transform.position.x < clone_place && !isCloned)
        {
            isCloned = true;
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Scroll, MessageType.Scroll_NewGround, groundID));
        }
        if (gameObject.transform.position.x < destroy_place)
        {
            destroy();
        }
    }
    public override void ReceiveMessage(Message message)
    {
        if (message.Command == MessageType.Scroll_NewGround && groundID == ((int[])message.Content)[1])
        {
            GameObject newGround = clone();
            if (((int[])message.Content)[0] == 0)
            {
                newGround.GetComponent<ScrollGround>().movespeed = ScrollManager.ScrollSpeed[0];
            }
            else if(((int[])message.Content)[0] == 1)
            {
                newGround.GetComponent<ScrollGround>().movespeed = ScrollManager.ScrollSpeed[1];
                if (groundID == 0)
                {
                    newGround.transform.position += new Vector3(0.647f, 12.384f, 0.0f);
                }
                if (groundID == 1)
                {
                    newGround.transform.position += new Vector3(-0.878f, 12.296f, 0.0f);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (groundID == 0)
            {
                movespeed = ScrollManager.ScrollSpeed[0];
                gameObject.transform.position = new Vector3(transform.position.x, -0.125f, 0.0f);
            }
            else if (groundID == 1)
            {
                movespeed = ScrollManager.ScrollSpeed[1];
            }
        }
    }
}
