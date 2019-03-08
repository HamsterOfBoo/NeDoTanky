using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : Tower
{
    public override float lookspeed { get; set; } = 2;
    public override float lookAngle { get; set; }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookOnEnemy();
    }


    public override void LookOnEnemy()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
            lookAngle = Quaternion.Angle(transform.rotation, targetRotation);
        }
    }
    
}


