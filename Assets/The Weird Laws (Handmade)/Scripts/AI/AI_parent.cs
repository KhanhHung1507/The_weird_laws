using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AI_parent : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D circle;
    [SerializeField] protected float speed;
    protected int randomPoints;
    [SerializeField] protected int MaxPoints;
    [SerializeField] protected int MinPoints;
    public Vector3 patrolPoints;

    [Header("References")]
    [SerializeField] LayerMask layer;
    [SerializeField] protected float radius = 0f;

    protected void Start()
    {
        patrolPoints = transform.parent.position;
    }

    protected void RadiusIncrease()
    {
        radius += Time.fixedDeltaTime;
        circle.radius = radius;
    }

    protected void Movement()
    {
        if(Condition()) return;
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, patrolPoints, speed*Time.fixedDeltaTime);
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -1f);
    }

    protected bool Condition()
    {
        return (patrolPoints == transform.parent.position);
    }

    protected void FindPatrolPoints()
    {
        if(!Condition()) 
        {
            randomPoints = Random.Range(MinPoints,MaxPoints);
            radius =0f;
            return;
        }
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.parent.position, radius, (Vector2)transform.parent.position, 0f, layer);

        if(hits.Length > randomPoints)
        {
            int stt = Random.Range(0, hits.Length);
            patrolPoints = hits[stt].transform.position;
        }
    }
}
