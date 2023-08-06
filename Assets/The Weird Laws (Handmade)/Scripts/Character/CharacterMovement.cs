using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected Joystick joystick;
    [SerializeField] protected float speed = 40f;
    [SerializeField] protected Animator myAnim;
    protected Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.Movement();
    }

    private void Movement()
    {
        Vector2 movement;
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
        myAnim.SetFloat("Speed", movement.sqrMagnitude);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
