using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMono : MonoBase
{
    // Start is called before the first frame update
    public Vector3 movespeed= new Vector3(0.0f,0.0f,0.0f);
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
        if (!isActive)
            ScrollManager.Register(this);
    }
    public virtual void behavior_fixed()
    {
        movespeed = ScrollManager.NowSpeed;
        if (isActive)
            move();
    }
    public virtual void move()
    {
        gameObject.transform.position = gameObject.transform.position - movespeed;
    }
    public virtual GameObject clone()
    {
        GameObject newmono=Instantiate(gameObject);
        newmono.GetComponent<ScrollMono>().isActive = true;
        newmono.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        newmono.GetComponent<Collider2D>().isTrigger = false;
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
