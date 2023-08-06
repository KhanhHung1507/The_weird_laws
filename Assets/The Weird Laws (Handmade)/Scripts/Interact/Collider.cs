using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
   [SerializeField] protected string _tag;
   [SerializeField] public bool boolen; 

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != _tag) return;
        boolen = true;
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != _tag) return;
        boolen = false;
    }
}
