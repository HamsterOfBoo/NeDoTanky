using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LookingOnMainCam : MonoBehaviour
{
    public Quaternion quaternion = new Quaternion(90,0,0,255);
    private void FixedUpdate()
    {
        transform.rotation = quaternion; 
    }

}
