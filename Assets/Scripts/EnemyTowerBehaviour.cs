using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerBehaviour : Tower
{

    public EnemyTankController enemy;
    
    public override float lookspeed { get; set; }
    public override float lookAngle { get; set; }

    public bool stopLooking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookspeed = 2;
        enemy = GetComponentInParent<EnemyTankController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemy.agroColliders.Length != 0)
            LookOnEnemy();
    }



    public override void LookOnEnemy()
    {
        if (!stopLooking)
        {
            Vector3 agroTarget = enemy.agroColliders[0].GetComponent<Tank>().transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(agroTarget - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
            lookAngle = Quaternion.Angle(transform.rotation, targetRotation);
        }
    }
}
