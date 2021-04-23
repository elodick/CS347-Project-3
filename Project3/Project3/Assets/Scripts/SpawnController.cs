using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the enemy spawners in the rooms. The spawnpoints are placed onto the scene and then added to this object via the Inspector.  
 * This script using a Normal Distribution to determine the number of enemies that are spawned per wave per room, 
 * where mean = average number of enemies to spawn, variance = standard deviation around the mean
 * Our default value is a mean of 5 enemies per round, with a standard deviation of 1 (i.e, 95% of rooms will spawn 4-6 enemies*/

public class SpawnController : MonoBehaviour
{
    // The list of enemies is the pool the spawner will select enemies from
    public List<GameObject> enemies;

    // The list of spawnpoints the spawner will instantiate enemies onto
    public List<GameObject> spawnpoints;

   
    public GameObject door;
    public GameObject spawntrigger;
    public GameObject room;

    // Wave is number of times per room the spawner is active
    public int wave;

    // Enemies count is total number of enemies in Scene, original enemy count is number of enemies in the list of enemies. 
    public int enemiesCount;
    public int originalEnemyCount;

    // Weight is the individual value of each enemy.  Total weight is the cumulative weight of all enemies on screen.
    public int weight;
    public int totalWeight;
    
    // Variables for the normal distribution function.  
    public int mean, variance, maxIters, numRects;
    // Start is called before the first frame update
    void Start()
    {
        // On start up, the doors are inactivated.  The wave count is set to 2, and the list of enemies is populated.
        door.SetActive(false);
        wave = 2;
        originalEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // if the waves are "over" (wave = 0) and all spawned enemies are defeated (enemies count = original enemy count), then deactivated all doors.
        if (wave == 0 && enemiesCount == originalEnemyCount)
        {
            foreach(GameObject door in GameObject.FindGameObjectsWithTag("door"))
                door.SetActive(false);
        }

        // if there are a different number of enemies in the scene than the original count, the doors should be active.
        if (enemiesCount != originalEnemyCount)
            door.SetActive(true);

        // if there are still waves to cycle through, but there are currently no spawned enemies, make the spawn trigger active and reset the weight.
        if (wave > 0 && enemiesCount == originalEnemyCount)
        {
            spawntrigger.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
            weight = 0;
        }

        // Constantly update the list of enemies
        enemies = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    void spawnEnemy()
    {
        // Calculate the total weight of the enemies
        enemiesWeight();

        // Calculate the number of enemies to spawn using a normal distribution random variable
        float probabilityNum = Probabilities.RandomNormalVariable(mean, variance, maxIters, numRects);

        // round the resulting number to an int
        int numToSpawn = Mathf.RoundToInt(probabilityNum);

        // Populate the list of all available spawn points
        spawnpoints = new List<GameObject>();
        foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("spawnpoint"))
        {
            // Only want to use the spawnpoints near the player, so that spawnpoints in other rooms don't spawn enemies
            var distanceFromSpawnToPlayer = Vector2.Distance(GameObject.Find("Player").transform.position, spawn.transform.position);
            if (distanceFromSpawnToPlayer <= 20)
            {

                spawnpoints.Add(spawn);
            }
        }

        // Loop from 0 to number of enemies to spawn, picking a random enemy at a random spawn point to create.
        for (int i = 0; i < numToSpawn; i++)
        {
            var randNumSpawn = Random.Range(0, enemies.Count);
            var randSpawnLoc = Random.Range(0, spawnpoints.Count);

            // Make sure enemies have not gone over the weight limit
            if (totalWeight - weight < enemies[randNumSpawn].GetComponent<EnemyController>().weight)
            {
                randNumSpawn = Random.Range(0, enemies.Count);
            }
            else
            {
                Instantiate(enemies[randNumSpawn], spawnpoints[randSpawnLoc].transform.position, Quaternion.identity);
                enemies[randNumSpawn].SetActive(true);
                spawnpoints.RemoveAt(randSpawnLoc);
            }
        }

        // Once the spawner is done, one wave is complete. 
        wave--;
        enemiesWeight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the spawner collider, and there are still waves to spawn, and currently spawned enemies in the scene, begin spawning enemies.
        if (wave > 0 && enemiesCount == originalEnemyCount)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                spawnEnemy();

                // Deactive additional triggers so only one wave gets spawned at a time
                spawntrigger.SetActive(false);

                // Activate doors so player cannot exit room
                door.SetActive(true);

            }
        }
    }   

    // Loop through the list of enemies summing up their weights. 
    void enemiesWeight()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            weight += enemy.GetComponent<EnemyController>().weight;
        }
    }

}
