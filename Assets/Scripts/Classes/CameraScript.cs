using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Vector3 playerpos;
    private GameObject player;
    private float playervelocity;
    //private Vector3 debugvector3 = new Vector3(0, 5);

     
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //get gameobject of player
        playervelocity = player.GetComponent<Player>().getvelocity(); //get veloctiy of player
        //playerpos = player.transform.position; //get position of player
	}
	
	// LateUpdate is called once at the end of each frame
	void LateUpdate () { //LateUpdate() has it follow so we can prevent player from seeing beyond world, Update() has it stay with it
        playerpos = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerpos.x, playerpos.y, transform.position.z), Time.deltaTime* playervelocity); 
        //move towards player while maintaining z position
	}
}
