using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Behind : MonoBehaviour
{
    [SerializeField] protected Transform checkPos;
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
            return;
        }
        behind = false;     
    }

    private void SetBehind()
    {
        for(int i =0; i < willBehind.Count && behind; i++)
        {
            SpriteRenderer ren = willBehind[i].GetComponent<SpriteRenderer>();
            ren.material.color = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.3f);
            player.position = new Vector3(player.position.x, player.position.y, 0f);
        }

        for(int i =0; i < willBehind.Count && !behind; i++)
        {
            SpriteRenderer ren = willBehind[i].GetComponent<SpriteRenderer>();
            ren.material.color = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 1f);
            player.position = new Vector3(player.position.x, player.position.y, -1f);
        }
    }
}
