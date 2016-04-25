using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private GameObject enemy;
    private GameObject[] enemies;
    private GameObject[] spawnpoints;
    private Vector3 spawnplace;
    private Quaternion defaultrotation;
    private Menu menu;
    private int wave1;
    private int waves;
    private bool enemysalldead;

	// Use this for initialization
	void Start () {
        enemy = (GameObject)Resources.Load("Prefabs/Enemies/Enemy1", typeof(GameObject)); //locate object in prefabs
  
        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        wave1 = 5; //use level index for later levels
        waves = 3;
        enemysalldead = false;
        defaultrotation = Quaternion.Euler(0f, 0f, 0f);
        //Destroy(GameObject.FindGameObjectWithTag("Enemy"), 3f); //Uncomment to debug: Destroys enemy is scene to start waves 
        enemy.transform.localScale = new Vector3(4, 4, 0); //scale to what we have in scene 
        menu = gameObject.AddComponent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {
        //spawn enemies either in waves or constantly
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Length == 0) //set to 1 to debug
            //if (enemies.Length == 1) //Debug
            {
                enemysalldead = true;
            }
        for (int k = 0; k < waves; k++) //spawn 'waves' of enemies 
        {
            if (enemysalldead == true) //if no enemies alive
            {
                Wave(wave1); //spawn another wave
                enemysalldead = false; //enemies are alive
            }
            else
            {
                break;
            }
            if (waves - 1 == k)
            {
                menu.SendMessage("ReturnToMenu");
            }

           
        }
        

	}

    void SpawnHere(Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }

    void Wave(int enemycount)
    {
        int tempj;
        for(int j = 0; j < enemycount; j++)
        {
            tempj = j;
            tempj %= spawnpoints.Length;
            //SpawnHere(spawnpoints[tempj].transform.position, defaultrotation); //No offset
            if (j % 2 == 0) //offset
            {
                SpawnHere(spawnpoints[tempj].transform.position + new Vector3(j, j + 2), defaultrotation);
            }
            else
            {
                SpawnHere(spawnpoints[tempj].transform.position + new Vector3(j - 2, j), defaultrotation);
            }
        }
    }
}
