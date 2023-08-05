using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected Sprite[] status;
    [SerializeField] protected Joystick joystick;
    [SerializeField] protected float speed = 40f;
    [SerializeField] protected SpriteRenderer mySprtie;
    protected Rigidbody2D rb;
    protected bool run;
    protected Vector2 movement;
    protected int facing;
    protected Animator myAnim;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        this.Movement();
        this.Facing();
    }

    private void Movement()
    {
        movement.x = joystick.Horizontal*10;
        movement.y = joystick.Vertical*10;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Facing()
    {
        bool faced = false;
        if(movement.x > 0 && movement.x > movement.y && !faced)
        {
            facing = 1; //"right"
            faced = true;
        }

        if(movement.x < 0 && movement.x < movement.y && !faced)
        {
            facing = 2; //"left"
            faced = true;
        }

        if(movement.y > 0 && movement.x < movement.y && !faced)
        {
            facing = 3; //"up"
            faced = true;
        }

        if(movement.y < 0 && movement.x > movement.y && !faced)
        {
            facing = 4; //"down"
            faced = true;
        }

        mySprtie.sprite = status[facing]; 
        //myAnim.SetInteger("Facing", facing);
    }
}
