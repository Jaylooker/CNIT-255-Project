using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Vector3 playerpos;
    private GameObject player;
    private float playervelocity;
    //private Vector3 debugvector3 = new Vector3(0, 5);

     
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>().gameObject; //get gameobject of player
        playervelocity = player.GetComponent<Player>().getvelocity(); //get veloctiy of player
        playerpos = player.transform.position; //get position of player
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, playerpos, playervelocity); //look at play each frame (follow)
        // debugging 
        //playerpos = Vector3.MoveTowards(playerpos, debugvector3, playervelocity);
	}
}
