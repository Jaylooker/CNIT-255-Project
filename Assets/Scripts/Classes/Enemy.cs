using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float health;
    private Position pos = new Position();

    // Use this for initialization
	void Start () {
        health = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        pos.getposition();
	}

    void Patrol()
    {

    }
     void Attack()
    {

    }
}
