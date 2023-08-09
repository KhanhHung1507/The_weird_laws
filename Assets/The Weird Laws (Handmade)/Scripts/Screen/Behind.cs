using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Behind : MonoBehaviour
{
    [SerializeField] protected Transform checkPos;
    [SerializeField] protected bool condition;
    [SerializeField] protected Transform player;
    [SerializeField] protected List<GameObject> willBehind;
    [SerializeField] protected bool behind;

    private void Update()
    {
        this.CheckPositon();
        this.SetBehind();
    }

    private void CheckPositon()
    {
        if(player.position.y > checkPos.position.y)
        {
            behind = true;
            player.position = new Vector3(player.position.x, player.position.y, 0f);
            return;
        }
        player.position = new Vector3(player.position.x, player.position.y, -1f);
        behind = false;     
    }

    private void SetBehind()
    {
        for(int i =0; i < willBehind.Count && (!behind || !condition); i++)
        {
            SpriteRenderer ren = willBehind[i].GetComponent<SpriteRenderer>();
            ren.material.color = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 1f);       
        }
        
        for(int i =0; i < willBehind.Count && behind && condition; i++)
        {
            SpriteRenderer ren = willBehind[i].GetComponent<SpriteRenderer>();
            ren.material.color = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        condition = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player") return;
        condition = false;
    }
}
