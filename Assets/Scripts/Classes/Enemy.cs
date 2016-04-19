using UnityEngine;
using System.Collections;

public class Enemy : Person, IEnemyState {
    //isKinematic so need tranform.Position to move
    //float health 
    //Position position
    //navagent2d agent
    //rigidbody2d rb
    private GameObject[] path;
    private GameObject player;
    private Vector3 targetpos;
    private SpriteRenderer displaysprite;
    private Sprite deadsprite;
    private float velocity;
    private float sightdistance;
    private int i;
    private bool isDead;

    void Awake()
    {
        agent = gameObject.AddComponent<NavAgent2D>(); //creates accessor to NavAgent2D script
        rb = gameObject.GetComponent<Rigidbody2D>();
        displaysprite = gameObject.GetComponent<SpriteRenderer>();
        
        velocity = 5f;
        sightdistance = 3f;
        targetpos = new Vector3();
        i = 0;
        isDead = false; 
    }
    // Use this for initialization
	void Start () {
        health = 10f;
        //deadsprite.name = "DeadSprite"; //get sprite named deadsprite
        player = GameObject.FindGameObjectWithTag("Player");
        path = GameObject.FindGameObjectsWithTag("Waypoint"); //collect waypoint of path
    }
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(transform.position.x, transform.position.y); //get current position
        UpdateState();
      }

    public bool getisDead()
    {
        return isDead;
    }

    //functions from IEnemyState interface 
    public void Patrol() 
    {
            targetpos = path[i].transform.position; //set patrol 
            if (transform.TransformPoint(transform.position).Equals(transform.TransformPoint(targetpos))) //if enemy has reached the targetpos, then move to next one in array
            {
                i++;
                i = i % path.Length; //loop back 
            }
          
        transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * velocity); //move to targetpos 
    }
    public void Attack()
    {
        //agent.SetDestination(player.transform.position); //follow player
        Debug.Log("Attack!");
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
}
