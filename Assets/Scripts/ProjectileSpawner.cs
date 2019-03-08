using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Projectile projectile;
    public int damage = 10;
    public float attackSpeed = 2f;
    public float cooldown = 0f;


    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        if (Time.time > cooldown)
        {
            cooldown = Time.time + attackSpeed;
            Projectile proj= Instantiate(projectile, transform.position, transform.rotation);
            proj.tag = tag;
            proj.damage = damage;
            proj.Direction = transform.up;

        }
    }
}

