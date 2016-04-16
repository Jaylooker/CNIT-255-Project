using UnityEngine;
using System.Collections;

public class Enemy : Person {
    //isKinematic so need tranform.Position to move
    //float health 
    //Position position
    //navagent2d agent


    void Awake()
    {
        agent = gameObject.AddComponent<NavAgent2D>(); //creates accessor to NavAgent2D script
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
