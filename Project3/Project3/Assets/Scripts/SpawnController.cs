using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> spawnpoints;
    public GameObject door;
    public GameObject spawntrigger;
    public GameObject room;
    public int wave;
    public int enemiesCount;
    public int totalWeight;
    public int weight;
    public int originalEnemyCount;
    public int mean, variance, maxIters, numRects;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
        wave = 2;
        originalEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wave == 0 && enemiesCount == originalEnemyCount)
        {
            door.SetActive(false);
        }
        if (enemiesCount != originalEnemyCount)
            door.SetActive(true);
        if (wave > 0 && enemiesCount == originalEnemyCount)
        {
            spawntrigger.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
            weight = 0;
        }
        enemies = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    void spawnEnemy()
    {
        enemiesWeight();
        float probabilityNum = Probabilities.RandomNormalVariable(mean, variance, maxIters, numRects);
        int numToSpawn = Mathf.RoundToInt(probabilityNum);
        spawnpoints = new List<GameObject>();
        foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("spawnpoint"))
        {

            var distanceFromSpawnToPlayer = Vector2.Distance(GameObject.Find("Player").transform.position, spawn.transform.position);
            if (distanceFromSpawnToPlayer <= 20)
            {

                spawnpoints.Add(spawn);
            }
        }
        for (int i = 0; i < numToSpawn; i++)
        {
            var randNumSpawn = Random.Range(0, enemies.Count);
            var randSpawnLoc = Random.Range(0, spawnpoints.Count);
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


        wave--;
        enemiesWeight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (wave > 0 && enemiesCount == originalEnemyCount)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                spawnEnemy();
                spawntrigger.SetActive(false);
                door.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }   
    void enemiesWeight()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            weight += enemy.GetComponent<EnemyController>().weight;
        }
    }

}
