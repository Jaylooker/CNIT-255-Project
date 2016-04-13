using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float health;
    private Position pos = new Position();
    
	// Use this for initialization
	void Start () {
        health = 100f;
	}
	
	// Update is called once per frame
	void Update () {
        pos.getposition();
	}
}
