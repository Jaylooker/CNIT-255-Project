using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Person {
    //isKinematic so need tranform.Position to move
    //float health
    //Vector3 targetposition
    //navagent2d agent
    //boundaryscript boundary
    //audioclip audio1

    private Menu menu;
    private GameObject[] enemies;
    private Sprite BackgroundSprite;
    private const int LeftMouseButton = 0;
    private const int MiddleMouseButton = 2;
    private float velocity = 2f; //units per frame
    private float WASDspeed = 5f;
    private float attackdistance = .75f;
    public Text healthText;

    void Awake()
    {
        agent = gameObject.AddComponent<NavAgent2D>();  //creates accessor to NavAgent2D script
        menu = gameObject.AddComponent<Menu>();
        boundary = gameObject.AddComponent<BoundaryScript>();
        agent.setvelocity(velocity); //set speed
        damage = 10f;

    }
    
	// Use this for initialization
	void Start () {
        health = 100f;
        healthText.text = "Health: " + health;
        UpCollider = transform.FindChild("PlayerUpCollider").gameObject;
        DownCollider = transform.FindChild("PlayerDownCollider").gameObject;
        LeftCollider = transform.FindChild("PlayerLeftCollider").gameObject;
        RightCollider = transform.FindChild("PlayerRightCollider").gameObject; //colliders
        BackgroundSprite = GameObject.FindGameObjectWithTag("BackgroundTag").GetComponent<SpriteRenderer>().sprite;
        targetpos = transform.position; //use form movement
        UpCollider.SetActive(false);
        LeftCollider.SetActive(false);
        RightCollider.SetActive(false);  //colliders
        //DownCollider is active first as we start with down sprite
        //Debug.Log(BackgroundSprite.bounds);
        //Debug.Log(BackgroundSprite.bounds.extents.x * 20);
	}
	
	// Update is called once per frame
	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //get current position
        /*if (Input.GetMouseButton(LeftMouseButton) == true) //if left mouse on screen
               {
               SetTargetPosition();
              }
            MovePlayer();
         */

        if (health <= 0) //if no health return to menu scene
        {
            menu.SendMessage("ReturnToMenu");
        }

        if (Input.GetMouseButton(LeftMouseButton) == true) //if left click
        {
            foreach (GameObject enemy in enemies) //find each enemy
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) <= attackdistance) //if enemy is within attack range
                {
                    enemy.GetComponent<Enemy>().sethealth(enemy.GetComponent<Enemy>().gethealth() - damage); //enemy take damage
                    ChangeColor(enemy);

                    //Debug.Log(enemy.GetComponent<Enemy>().gethealth());
                }
            }
        } 
        if (Input.GetKey(KeyCode.W) == true && boundary.getTopBoundary() == false) //WASD if needed
        {
            targetpos = new Vector3(transform.position.x, transform.position.y + WASDspeed);
            agent.SetDestination(targetpos);
            UpCollider.SetActive(true); //change collider
            DownCollider.SetActive(false);
            LeftCollider.SetActive(false);
            RightCollider.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S) == true && boundary.getBottomBoundary() == false)
        {
            targetpos = new Vector3(transform.position.x, transform.position.y - WASDspeed);
            agent.SetDestination(targetpos);
            UpCollider.SetActive(false); //change collider
            DownCollider.SetActive(true);
            LeftCollider.SetActive(false);
            RightCollider.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A) == true && boundary.getLeftBoundary() == false)
        {
            targetpos = new Vector3(transform.position.x - WASDspeed, transform.position.y);
            agent.SetDestination(targetpos);
            UpCollider.SetActive(false); //change collider
            DownCollider.SetActive(false);
            LeftCollider.SetActive(true);
            RightCollider.SetActive(false);
         }
         if (Input.GetKey(KeyCode.D) == true && boundary.getRightBoundary() == false)
         {
            targetpos = new Vector3(transform.position.x + WASDspeed, transform.position.y);
            agent.SetDestination(targetpos);
            UpCollider.SetActive(false); //change collider
            DownCollider.SetActive(false);
            LeftCollider.SetActive(false);
            RightCollider.SetActive(true);
          }
        healthText.text = "Health: " + health;
    }

    void FixedUpdate() //for physics (i.e. colliders)
    {
        boundary.CheckBoundaryFor("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.GetType() == typeof(BoxCollider2D)) //if box collider 
        {
            while (col.tag == "Enemy") //while enemy has collided with player
            {
                health -= col.GetComponent<Enemy>().getDamage(); //subract enemy damage
                Timer(2f);
            }
        }
    }

    void SetTargetPosition() //needs work
    {
        //float cameraz = Camera.main.transform.position.z;
        /*float point = 0f;
        Plane plane = new Plane(Vector3.up, transform.position); //creates a plane at player position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Finds a ray pointing from the camera at where the mouse has clicked
        if (plane.Raycast(ray, out point) == true)
        {
            targetpos = ray.GetPoint(point);
        }*/
        //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //targetpos.z = transform.position.z;
        
        //Debug.Log(Input.mousePosition);
        //Debug.Log(targetpos.ToString());
    }

    void MovePlayer()
    {
        agent.SetDestination(targetpos);

        //Debug.DrawLine(transform.position, targetpos, Color.red); //see if it works
    }

    public float getvelocity()
    {
        return velocity;
    }

    public void ChangeColor(GameObject gm)
    {
        gm.GetComponent<SpriteRenderer>().color = Color.blue;

    }

    public IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


}
