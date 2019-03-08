using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Tower : MonoBehaviour
{
    public abstract float  lookspeed { get; set; }
    public abstract float lookAngle { get; set; }
    public Rigidbody rb;

    void Start()
    {
    }

    public abstract void LookOnEnemy();

    public void AddRb()
    {
        rb = gameObject.AddComponent<Rigidbody>();
    }

}
