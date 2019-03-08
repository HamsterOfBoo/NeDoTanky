using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    public int maxHp = 100;
    public int currentHp = 100;
    public int armour = 0;
    public float timeBetweenDestroy = 8;
    public Slider hpBar;

    public Tower _towerBehaviour;
    public bool isDied = false;
    private TankController _tankController;
    private NavMeshAgent navAgent;
    


    private void Start() 
    {
        navAgent = GetComponent<NavMeshAgent>();
        hpBar.value = currentHp;
        _towerBehaviour = GetComponentInChildren<Tower>();
        _tankController = GetComponentInChildren<TankController>();
    }

    private void FixedUpdate()
    {
        if (isDied)
        {
            StartCoroutine(DrownTank());
        }
    }

    public void TakeDamage (int dmg)
    {
        if (dmg - armour > 0)
        {
            currentHp -= dmg - armour;
            hpBar.value = currentHp;
        }
        if (currentHp <= 0) TankDestroy();
    }
    
    

    void TankDestroy()
    {
        isDied = true;
        _towerBehaviour.AddRb();
        _towerBehaviour.rb.AddForce(Random.Range(-80.0f, 80.0f), Random.Range(170.0f, 340.0f), Random.Range(-80.0f, 80.0f));
        _towerBehaviour.rb.AddTorque(Random.Range(170.0f, 340.0f),Random.Range(-80.0f, 80.0f), Random.Range(170.0f, 340.0f));
        Destroy(navAgent);
        Destroy(_tankController);
        Destroy(_towerBehaviour.rb,4);
        Destroy(gameObject,timeBetweenDestroy);
        
        if (gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
            GetComponentInChildren<Canvas>().enabled = false;
    }

    private IEnumerator DrownTank()
    {
        yield return new WaitForSeconds(4f);
        transform.Translate(Vector3.down * Time.deltaTime*0.5f);
    }

    
     
}
