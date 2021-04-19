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
    public float flameRange;
    public float flameLength;
    private LineRenderer line;
    private Vector3 mousePos;
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        line = player.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0)
            basicShot();
        if (Input.GetMouseButtonDown(1) && timer <= 0)
            spreadShot();
        if (Input.GetMouseButtonDown(2) && timer <= 0)
        {
            line.positionCount = 2;
            flameShot();
        }
        if (Input.GetMouseButtonUp(2))
            line.positionCount = 0;
        firePoint = player.transform;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        mousePos = player.GetComponent<PlayerController>().cam.ScreenToWorldPoint(Input.mousePosition); ;
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

    void flameShot()
    {
        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, mousePos / flameLength);
    }
}