using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] SpriteRenderer door;
    [SerializeField] protected Sprite[] status;
    [SerializeField] protected bool open = false;

    private void Update()
    {
        this.Door();
    }

    private void Door()
    {
        if(!open)
        {
            door.sprite = status[0];
            return;
        }

        door.sprite = status[1];
    }
}
