using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFurniture : ScrollMono
{
    // Start is called before the first frame update
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
        BoundSpeed_now -= a * Time.fixedDeltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + BoundSpeed_now);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            BoundSpeed_now = BoundSpeed;
        }
    }
}
