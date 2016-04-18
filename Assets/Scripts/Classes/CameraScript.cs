using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Transform focus;
    private GameObject player;
    private float playervelocity;

     
	// Use this for initialization
	void Start () {
        focus.tag = "Player"; //find player
        player = focus.gameObject;
        playervelocity = player.GetComponent<Player>().getvelocity();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, focus.position, playervelocity); //look at play each frame (follow)
	}
}
