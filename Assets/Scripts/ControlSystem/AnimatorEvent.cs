using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    public Animator animator;
    public AnimationEvent animEvent;
    public AnimationClip clip;

    private void Start()
    {
        animEvent = new AnimationEvent();
        animEvent.functionName="test";
    }

    public void test()
    {
        animator.SetBool("IsHurt", false);
    }
}
