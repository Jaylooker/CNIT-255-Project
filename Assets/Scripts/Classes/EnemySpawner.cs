using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private GameObject enemy;
    private GameObject[] enemies;
    private GameObject[] spawnpoints;
    private Vector3 spawnplace;
    private int wave1;
    private int waves;
    private int i;
    private bool enemysalldead;

	// Use this for initialization
	void Start () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        i = 0;
        wave1 = 5; //use level index for later levels
        waves = 3;
        enemysalldead = false;
	}
	
	// Update is called once per frame
	void Update () {
        //spawn enemies either in waves or constantly
            if (enemies.Length == 0)
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
           
        }
        

	}

    void SpawnHere(Vector3 position)
    {
        Instantiate(enemy, position, enemy.transform.rotation);
    }

    void Wave(int enemycount)
    {
        int tempj;
        for(int j = 0; j < enemycount; j++)
        {
            tempj = j;
            tempj %= spawnpoints.Length;
            SpawnHere(spawnpoints[tempj].transform.position);
        }
    }
}
