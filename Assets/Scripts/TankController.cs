using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class TankController : MonoBehaviour
{
    public NavMeshAgent navAgent { get; set; }

    public ProjectileSpawner projSpawner { get; set; }
    public Vector3 oldPos;
    protected Tower towerController;

    public abstract void Move();

    public void Stop()
    {
        navAgent.isStopped = true;
    }
    public abstract IEnumerator StopAndShot();
}
