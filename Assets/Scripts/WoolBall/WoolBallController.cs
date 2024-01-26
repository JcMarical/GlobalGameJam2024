using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WoolBallStateType
{
    Default,Upset,Happy,Happiest
}


#region 属性
[Serializable]
public class WoolBallParameter : FurnitureParameter
{
    [Header("毛球特殊属性")] 
    public float throwMinSpeed;

    public float throwMaxSpeed;
}

#endregion

public class WoolBallController : MonoBehaviour
{
    public WoolBallParameter parameter;

    private IState currentState;

    private Dictionary<WoolBallStateType, IState> states = new Dictionary<WoolBallStateType, IState>();

    // Start is called before the first frame update
    void Start()
    {
        parameter.animator = GetComponent<Animator>();
        
        states.Add(WoolBallStateType.Default,new WoolballDefaultState(this));
        states.Add(WoolBallStateType.Upset,new WoolBallUpsetState(this));
        states.Add(WoolBallStateType.Happy,new WoolBallHappyState(this));
        states.Add(WoolBallStateType.Happiest,new WoolBallHappiestState(this));
        TransitonState(WoolBallStateType.Default);
        parameter.rigid = GetComponent<Rigidbody2D>();
        parameter.rigid.velocity = Vector2.left* Random.Range(parameter.throwMinSpeed,parameter.throwMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();

    }

    public void TransitonState(WoolBallStateType type)
    {
        if (currentState! != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if(target != null)
        {
            if(transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
}
