using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingAI : EnemyController
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject bulletPrefab;
    
    [SerializeField]
    public float bulletForce = 1f;

  
    public float AttackDelay = 1f;

    public float AttackTime;

    private bool shootDir;

    //Where to spawn bullets when firing 
    [SerializeField]
    Transform up;
    [SerializeField]
    Transform down;
    [SerializeField]
    Transform left;
    [SerializeField]
    Transform right;
    [SerializeField]
    Transform TopRight;
    [SerializeField]
    Transform BottomRight;
    [SerializeField]
    Transform TopLeft;
    [SerializeField]
    Transform BottomLeft;
    override protected void Start()
    {
        base.Start();
        AttackTime = AttackDelay;    
    }
    override protected void FixedUpdate()
    {
        // Decrease attack time by delta time
        base.FixedUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        if(timer <=0)
        {
            if (shootDir == true)
            {
                shootDir = false;
            }
            else
            {
                shootDir = true;
            }
            Shoot(shootDir);
            timer = AttackDelay;
        }
    }
    private void Shoot(bool shootDir)
    {
        if (behavior == Behavior.ATTACK)
        {
            if (shootDir == true) //Shoot in a PLUS sign pattern
            {
                GameObject bullet1 = Instantiate(bulletPrefab);
                bullet1.transform.position = up.transform.position;
                bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletForce, 0);
                GameObject bullet2 = Instantiate(bulletPrefab);
                bullet2.transform.position = down.transform.position;
                bullet2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletForce, 0);
                GameObject bullet3 = Instantiate(bulletPrefab);
                bullet3.transform.position = left.transform.position;
                bullet3.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletForce, 0, 0);
                GameObject bullet4 = Instantiate(bulletPrefab);
                bullet4.transform.position = right.transform.position;
                bullet4.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletForce, 0, 0);
            }
            else            //Shoot in an "X" Pattern 
            {
                GameObject bullet1 = Instantiate(bulletPrefab);
                bullet1.transform.position = TopLeft.transform.position;
                bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletForce, bulletForce, 0);
                GameObject bullet2 = Instantiate(bulletPrefab);
                bullet2.transform.position = TopRight.transform.position;
                bullet2.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletForce, bulletForce, 0);
                GameObject bullet3 = Instantiate(bulletPrefab);
                bullet3.transform.position = BottomLeft.transform.position;
                bullet3.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletForce, -bulletForce, 0);
                GameObject bullet4 = Instantiate(bulletPrefab);
                bullet4.transform.position = BottomRight.transform.position;
                bullet4.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletForce, -bulletForce, 0);
            }
        }
    }
}
