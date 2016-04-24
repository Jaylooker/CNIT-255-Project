using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Person, IEnemyState {
    //isKinematic so need tranform.Position to move
    //float health 
    //Vector3 targetpos
    //navagent2d agent
    //boundaryscript boundary
    //audioclip audio1

    private List<GameObject> pathways = new List<GameObject>();
    private /*List<GameObject>*/ GameObject[] path; 
    private GameObject player;
    private SpriteRenderer displaysprite;
    private Sprite deadsprite;
    private float velocity;
    private float sightdistance;
    private int i;
    private float damage;
    private bool isDead;
    private double randomvar;

    void Awake()
    {
        agent = gameObject.AddComponent<NavAgent2D>(); //creates accessor to NavAgent2D script
        boundary = gameObject.AddComponent<BoundaryScript>();
        displaysprite = gameObject.GetComponent<SpriteRenderer>();
        isDead = false;
        velocity = 1f;
        sightdistance = 4f;
        targetpos = new Vector3();
        i = 0;
        damage = 10;
    }
    // Use this for initialization
	void Start () {
        health = 10f;
        //deadsprite.name = "DeadSprite"; //get sprite named deadsprite
        randomvar = Random.value; //get random number
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(GameObject.FindGameObjectsWithTag("Path").ToString());
        /*pathways.AddRange(GameObject.FindGameObjectsWithTag("Path")); //collect paths
        Debug.Log(pathways); 
        for (int i = 0; i < pathways.Count; i++) //go through each path is pathways
        {
            if (randomvar >= i / pathways.Count && randomvar <= (i+ 1)/ pathways.Count) //if the random variable is between n/paths and n+1/paths 
            {
                foreach (Transform waypoint in pathways[i].transform) //set the path to those waypoints
                {
                    if (waypoint.tag == "Path")
                    {
                        path.Add(waypoint.gameObject);
                        //Debug.Log(waypoint.gameObject.ToString());
                    }
                }
            }
        }
        */
        //path.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
        path = GameObject.FindGameObjectsWithTag("Waypoint");
    }
	
    void FixedUpdate()
    {
        boundary.CheckBoundaryFor("Enemy");
    }
	// Update is called once per frame
	void LateUpdate ()
    {
        UpdateState();
    }

    public bool getisDead()
    {
        return isDead;
    }

    public float getDamage()
    {
        return damage;
    }

    //functions from IEnemyState interface 
    public void Patrol() 
    {
            targetpos = path[i].transform.position; //set patrol
            if (transform.position == targetpos) //if enemy has reached the targetpos, then move to next one in array
            {
                i++;
                i = i % path.Length; //loop back 
            }
        StayInBounds();
        transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * velocity); //move to targetpos 
    }
    public void Attack()
    {
        targetpos = player.transform.position;
        StayInBounds();
        transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * velocity);
        //agent.SetDestination(player.transform.position); //follow player
        //Debug.Log("Attack!");
    }
    public IEnumerator Dead() 
    {
        displaysprite.sprite = deadsprite; //display dead sprite
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    public void UpdateState()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= sightdistance && isDead == false)
        {
            Patrol();
        }
        else if (isDead == false)
        {
            Attack();
        }
        else
        {
            StartCoroutine(Dead());
        }
        
    }

    public void StayInBounds()
    {
        if (boundary.getTopBoundary() == true)
        {
            //targetpos.y = boundary.getTopBoundary().point.y;
            targetpos.y = Mathf.Clamp(targetpos.y, 0, boundary.getTopBoundary().point.y);
        }
        if (boundary.getBottomBoundary() == true)
        {
           // targetpos.y = boundary.getTopBoundary().point.y;
            targetpos.y = Mathf.Clamp(targetpos.y, 0, boundary.getTopBoundary().point.y);
        }
        if (boundary.getLeftBoundary() == true)
        {
            //targetpos.x = boundary.getTopBoundary().point.x;
            targetpos.x = Mathf.Clamp(targetpos.x, 0, boundary.getTopBoundary().point.x);
        }
        if (boundary.getRightBoundary() == true)
        {
            //targetpos.x = boundary.getTopBoundary().point.x;
            targetpos.x = Mathf.Clamp(targetpos.x, 0, boundary.getTopBoundary().point.x);
        }
    }
}
