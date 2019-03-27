using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController : TankController
{
    public LayerMask agroMask;
    public int agroRange = 15;

    public Collider[] agroColliders;
    private bool IsAttacking = false;
    
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        projSpawner = GetComponentInChildren<ProjectileSpawner>();
        towerController = GetComponentInChildren<EnemyTowerBehaviour>();
        
        oldPos = transform.position;
    }

    void FixedUpdate()
    {

        agroColliders =  Physics.OverlapSphere(transform.position, agroRange, agroMask);
        if (agroColliders.Length > 0)
        {
            if (Time.time > projSpawner.cooldown)
                StartCoroutine(StopAndShot());
            if (!IsAttacking)
            {
                //Танк существует 8 сек. Переделать что-то.
                Move(agroColliders[0].GetComponent<Tank>());
            }
        }
        else
            navAgent.isStopped = true;


    }


    void Move(Tank tank)
    {
        navAgent.SetDestination(tank.transform.position);
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator StopAndShot()
    {
        while (true)
        {
            navAgent.isStopped = true;
            IsAttacking = true;
            if (oldPos.magnitude - transform.position.magnitude == 0f && towerController.lookAngle < 15)
            {
                yield return new WaitForSeconds(1f);
                oldPos = transform.position;
                projSpawner.Spawn();
                navAgent.isStopped = false;
                IsAttacking = false;
                yield break;
            }

            oldPos = transform.position;
            yield return null;
        }
    }
   
}
