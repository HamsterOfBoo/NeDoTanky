using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rigitBody;
    public Vector3 Direction;
    private Vector3 spawnPosition;
    private ProjectileSpawner projSpawner;
    private Tank _enemyTank;
    
    public int damage;
    public float force = 8f;
    public float TimeBetweenDestroy = 10f;
    

    
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Direction * force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject,TimeBetweenDestroy);
    }

    void OnCollisionEnter(Collision col)
    {
        _enemyTank = col.gameObject.GetComponentInParent<Tank>();
        if ( _enemyTank!= null && !_enemyTank.isDied && !_enemyTank.CompareTag(tag) )
        {
            Destroy(gameObject);
            col.gameObject.GetComponentInParent<Tank>().TakeDamage(damage);
        };
        

    }
}
