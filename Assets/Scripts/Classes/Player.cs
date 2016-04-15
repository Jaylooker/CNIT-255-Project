using UnityEngine;
using System.Collections;

public class Player : Person {
    //isKinematic so need tranform.Position to move
    //float health
    //Position position
    //navmeshagent agent
    private Vector3 targetpos;
    private const int LeftMouseButton = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); //reference to component
        GetComponent<NavMeshAgent>().enabled = true;
    }
    
	// Use this for initialization
	void Start () {
        health = 100f;
        pos = transform.position; //use for enemy detection
        targetpos = transform.position; //use form movement
	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(transform.position.x, transform.position.y); //get current position
        if (Input.GetMouseButton(LeftMouseButton) == true)
        {
            SetTargetPosition();
        }
        MovePlayer();
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.zero, transform.position); //creates a plane at (0,0,0)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Finds a ray pointing from the camera at where the mouse has clicked
        float point = 0f;
        if(plane.Raycast(ray, out point) == true) //if mouse click intersects the plane set the target position to that point of intersection
        {
            targetpos = ray.GetPoint(point);
        }
    }

    void MovePlayer()
    {
        agent.SetDestination(targetpos);

        Debug.DrawLine(transform.position, targetpos, Color.red); //see if it works
    }


}
