using UnityEngine;
using System.Collections;

public class Enemy : Person {
    //isKinematic so need tranform.Position to move
    //float health 
    //Position position
    //navmeshagent agent

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); //reference to component
        GetComponent<NavMeshAgent>().enabled = true;
        
    }
    // Use this for initialization
	void Start () {
        health = 10f;



	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(transform.position.x, transform.position.y); //get current position
    }


    //functions from IEnemyState interface 
    void Patrol()
    {

    }
     void Attack()
    {

    }
}
