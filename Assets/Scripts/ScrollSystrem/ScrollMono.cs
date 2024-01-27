using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMono : MonoBase
{
    // Start is called before the first frame update
    public float movespeed;
    public bool isActive=false;
    public float destroy_place = -24.0f;
    void Start()
    {
        behavior_start();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        behavior_fixed();
    }
    void Update()
    {
        if (gameObject.transform.position.x < destroy_place)
        {
            destroy();
        }
    }
    public virtual void behavior_start()
    {
        movespeed = ScrollManager.ScrollSpeed;
        if (!isActive)
            ScrollManager.Register(this);
    }
    public virtual void behavior_fixed()
    {
        if (isActive)
            move();
    }
    public virtual void move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - movespeed, gameObject.transform.position.y);
    }
    public virtual GameObject clone()
    {
        GameObject newmono=Instantiate(gameObject);
        newmono.GetComponent<ScrollMono>().isActive = true;
        newmono.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        return newmono;
    }

    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
    public override void ReceiveMessage(Message message)
    {
    }
}
