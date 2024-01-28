using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleThingController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInteracting;
    public float judgeHeight;
    public Rigidbody2D rigid;

    public float throwMinSpeed;
    public float throwMaxSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left* Random.Range(throwMinSpeed,throwMaxSpeed);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            if (!other.GetComponentInParent<Player>().isInteracting)
            {
                if (other.transform.position.y > transform.position.y + judgeHeight)
                {
                    transform.position = new Vector3(other.transform.position.x, transform.position.y);
                    //MessageCenter.SendCustomMessage(new Message(MessageType.Type_Player, MessageType.WoolBall_Interact, null));
                    // MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.WoolBall_Interact, null));
                    isInteracting = true;
                }
                else
                {
                    MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Controll_Jump, null));
                    MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_Hurt, null));
                    Destroy(gameObject.GetComponent<Collider2D>());
                }
            }
            else
            {
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Controll_Down, null));
                MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Player_Hurt, null));
                Destroy(gameObject.GetComponent<Collider2D>());
            }
        }
    }
    
    
}
