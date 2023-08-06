using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors : MonoBehaviour
{
    [SerializeField] protected Collider testforPlayer;
    [SerializeField] protected SpriteRenderer door; 
    [SerializeField] protected Sprite[] status;
    [SerializeField] protected bool open = false;
    [SerializeField] protected GameObject Button;
    [SerializeField] protected Image buttonImage;
    
    private void Update()
    {
        this.Door();
        this.ButtonDoor();
        this.InteractWithDoor();
    }

    private void Door()
    {
        if(!open)
        {
            door.sprite = status[0];
            buttonImage.sprite = status[1];
            return;
        }

        door.sprite = status[1];
        buttonImage.sprite = status[0];
    }

    private void ButtonDoor()
    {
        Button.SetActive(testforPlayer.boolen);   
    }

    private void InteractWithDoor()
    {
        if(!testforPlayer.boolen) return;

        TouchOn _touch = Button.GetComponent<TouchOn>();
        if(!_touch.touch) return;
        
        _touch.touch = false;
        if(!open)
        {
            open = true;
            return;
        }

        open = false;
    }
}
