using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : AI_parent
{
    [SerializeField] protected float speed = 5f;
    protected Vector2 movement;
    protected float time;
    protected float timeCurrent;
    protected bool run = true;
    protected Rigidbody2D rb;

    private void Awake()
    {
        movement = new Vector2(transform.parent.position.x , transform.parent.position.y);
        time = TimeRun();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    protected void Update()
    {
        this.Move();
        this.MakeDestination();
    }

    protected void Move()
    {
        if(!run) return;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, movement, speed*Time.deltaTime);
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -1f);     
    }

    protected void MakeDestination()
    {
        timeCurrent += Time.deltaTime;
        if(timeCurrent < time) return;
        run = true;
        this.GetDestination();
    }

    protected void GetDestination()
    {
        if(!CheckPs(movement, transform.parent.position)) return;
        timeCurrent = 0f;        
        time = TimeRun();
        Vector2 origin = new Vector2(transform.parent.position.x , transform.parent.position.y);
        movement = origin + AI_move();   
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        print("true");
        run = false;
    }
}
