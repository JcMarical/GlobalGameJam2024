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
    public float interactionRotateSpeed;
}

#endregion

public class WoolBallController : FurnitureController<WoolBallParameter,WoolBallStateType>
{
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

    #region API
    public override void StartInteract(float height)
    {
        parameter.rigid.velocity = Vector2.zero;
        parameter.rigid.angularVelocity = 0;
        transform.position += new Vector3(0, height, 0);
        parameter.rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        TransitonState(WoolBallStateType.Upset);
    }
    

    #endregion

}
