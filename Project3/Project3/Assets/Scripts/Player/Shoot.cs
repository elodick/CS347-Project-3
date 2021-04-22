
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spreadPellet;

    private GameObject player;
    private Rigidbody2D playerRB;
    public float bulletForce = 20f;
    public float spreadWidth;
    public float timer;
    private float firingSpeed;
    public int numOfSpread;
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        numOfSpread = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 
        firingSpeed = GetComponent<PlayerController>().firingSpeed;
        var shotType = GameObject.Find("Player").GetComponent<PlayerController>().shotType;
        switch (shotType)
        {
            case 0:
                if (Input.GetMouseButtonDown(0) && timer <= 0)
                    BasicShot();
                break;
            case 1:
                if (Input.GetMouseButtonDown(0) && timer <= 0)
                    SpreadShot();
                break;
        }
    }

    private void FixedUpdate()
    {
        
    }
    
    void BasicShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        timer = firingSpeed;
    }

    void SpreadShot()
    {
        for (int i = 0; i < numOfSpread; i++)
        {
            firePoint.transform.rotation = Quaternion.Euler(0, 0, Random.Range(playerRB.rotation-15,playerRB.rotation+15));
            GameObject bullet = Instantiate(spreadPellet, transform.position + new Vector3(0, 0, i / spreadWidth), firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        timer = firingSpeed;
    }
}