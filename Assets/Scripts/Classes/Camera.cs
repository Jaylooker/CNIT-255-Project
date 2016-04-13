using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private Transform target;
     
	// Use this for initialization
	void Start () {
        target.tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
