using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMono : MonoBase
{
    // Start is called before the first frame update
    public float movespeed=0.1f;
    public bool isActive=false;
    public float destroy_place = -24.0f;
    void Start()
    {
        if(!isActive)
        GroundManager.Register(this);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isActive)
            move();
    }
    void Update()
    {
        if (gameObject.transform.position.x < destroy_place)
        {
            destroy();
        }
    }
    public virtual void move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - movespeed, gameObject.transform.position.y);
    }
    public void clone()
    {
        GameObject newground=Instantiate(gameObject);
        newground.GetComponent<ScrollMono>().isActive = true;
    }

    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
    public override void ReceiveMessage(Message message)
    {
    }
}
