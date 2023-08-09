using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_parent : MonoBehaviour
{
    protected float TimeRun()
    {
        float time = Random.Range(3f,7f); 
        return time;
    }

    protected bool CheckPs(Vector2 destination, Vector2 position)
    {
        if(destination != position) return false;
        return true;
    }

    protected Vector2 AI_move()
    {
        Vector2 move;
        move.x = Random.Range(-2f,2f);
        move.y = Random.Range(-2f,2f);
        return move;
    }
}
