using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Friend : AI_parent
{
    [SerializeField] protected Animator myAnim;
    protected Vector2 movement;

    protected void Update()
    {
        RadiusIncrease();
        FindPatrolPoints();
        Movement();
        this.GetAxis(); 
        this.Animation();
    }

    protected void GetAxis()
    {
        movement = patrolPoints - transform.parent.position;
    }

    protected void Animation()
    {
        myAnim.SetBool("Run", !Condition());
        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
    }
}
