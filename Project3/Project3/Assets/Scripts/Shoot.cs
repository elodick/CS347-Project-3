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
    private float timer;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0)
            basicShot();
        if (Input.GetMouseButtonDown(1) && timer <= 0)
            spreadShot();
        firePoint = player.transform;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void basicShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        timer = 0.75f;
    }

    void spreadShot()
    {
        for (int i = 0; i < 4; i++)
        {
            firePoint.transform.rotation = Quaternion.Euler(0, 0, Random.Range(playerRB.rotation-15,playerRB.rotation+15));
            GameObject bullet = Instantiate(spreadPellet, transform.position + new Vector3(0, 0, i / spreadWidth), firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        timer = 0.5f;
    }
}
