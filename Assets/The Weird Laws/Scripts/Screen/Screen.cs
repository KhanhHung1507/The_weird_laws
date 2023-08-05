using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] protected Transform Target;
    
    protected void Update()
    {
        this.CameraMove();
    }

    protected void CameraMove()
    {
        Camera.main.transform.position = new Vector3(Target.position.x, Target.position.y, -10f);
    }
}
