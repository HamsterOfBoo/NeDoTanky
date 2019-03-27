using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlliesTankController : TankController
{



    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        projSpawner = GetComponentInChildren<ProjectileSpawner>();
        towerController = GetComponentInChildren<TowerBehaviour>();
        oldPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
            Move();
        if (Input.GetMouseButtonDown(0) && Time.time > projSpawner.cooldown)
            StartCoroutine(StopAndShot());


    }

    public override void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
        {
                navAgent.destination = rayHit.point;
        }
    }

    public override IEnumerator StopAndShot()
    {
        while (true)
        {
            navAgent.isStopped = true;
            if (towerController.lookAngle<2f)
            {
                if(oldPos.magnitude - transform.position.magnitude != 0f ) yield return new WaitForSeconds(1f);
                oldPos = transform.position;
                projSpawner.Spawn();
                navAgent.isStopped = false;
                yield break;
            }

            oldPos = transform.position;
            yield return null;
        }
    }
}
