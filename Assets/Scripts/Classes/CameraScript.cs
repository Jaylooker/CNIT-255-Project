using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Transform focus;

     
	// Use this for initialization
	void Start () {
        focus.tag = "Player"; //find player
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.LookAt(focus); //look at play each frame (follow)
	}
}
