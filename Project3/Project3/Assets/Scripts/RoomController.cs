using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> spawnpoints;
    public GameObject door;
    public GameObject spawntrigger;
    public GameObject room;
    public int wave;
    public int enemiesCount;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
        wave = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wave == 0 && enemiesCount == 3)
        {
            door.SetActive(false);
        }
        if (enemiesCount != 3)
            door.SetActive(true);
        if (wave > 0 && enemiesCount == 3)
        {
            spawntrigger.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
        }
        enemies = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void spawnEnemy(int numToSpawn)
    {
        spawnpoints = new List<GameObject>();
        foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("spawnpoint"))
        {
            spawnpoints.Add(spawn);
        }
        for (int i = 0; i < numToSpawn; i++)
        {
            var randNumSpawn = Random.Range(0, enemies.Count);
            var randSpawnLoc = Random.Range(0, spawnpoints.Count);
            Instantiate(enemies[randNumSpawn], spawnpoints[randSpawnLoc].transform.position, Quaternion.identity);
            spawnpoints.RemoveAt(randSpawnLoc);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (wave > 0 && enemiesCount == 3)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                spawnEnemy(5);
                spawntrigger.SetActive(false);
                door.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            wave--;
        }
    }   
}
