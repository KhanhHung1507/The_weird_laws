using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOn : MonoBehaviour
{
    [SerializeField] public bool touch;

    public void Touch()
    {
        touch = !touch;
    }
}
