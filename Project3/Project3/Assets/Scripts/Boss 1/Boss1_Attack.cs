using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Attack : MonoBehaviour
{
    [SerializeField]            //Prefabs to instantiate
    GameObject ChaseEnemy;

    [SerializeField]            
    GameObject Bullet, ExplosiveBullet;

    [SerializeField]        //Bullet speed
    public float BSpeed;

    /*
    [SerializeField]
    public float BaseBdelay, BaseShootDuration;


    public float Bdelay, ShootDuration;

    */
    [SerializeField]
    Transform Spawn1;

    [SerializeField]
    Transform Spawn2;

    [SerializeField]
    Transform ShootL;

    [SerializeField]
    Transform ShootR;

    [SerializeField]
    Transform ShootM;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
       // Bdelay -= Time.deltaTime;
       // ShootDuration -= Time.deltaTime;
    }
    private void Update()
    {
        /*
        if (Bdelay <= 0) // Reset Move Time and swap move directions
        {
            Bdelay = BaseBdelay;
            
        }
        if(ShootDuration <= 0)
        {
            ShootDuration = BaseShootDuration;
        }
        */
    }


    public void SpawnEnemies()
    {
        GameObject Enemy1 = Instantiate(ChaseEnemy);
        GameObject Enemy2 = Instantiate(ChaseEnemy);
        Enemy1.gameObject.transform.localScale = new Vector2(5,5); //scale up the slime size 
        Enemy2.gameObject.transform.localScale = new Vector2(5, 5);
        Enemy1.transform.position = Spawn1.transform.position;
        Enemy2.transform.position = Spawn2.transform.position;
    }

    public void ShootBullets()
    {
        
                GameObject bullet1 = Instantiate(Bullet);
                bullet1.transform.position = ShootL.transform.position;
                bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -BSpeed, 0);
                GameObject bullet2 = Instantiate(Bullet);
                bullet2.transform.position = ShootR.transform.position;
                bullet2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -BSpeed, 0);
                 GameObject bullet3 = Instantiate(Bullet);
                    bullet3.transform.position = ShootM.transform.position;
                 bullet3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -BSpeed, 0);

    }
    public void ShootExplosion()
    {
        GameObject bullet1 = Instantiate(ExplosiveBullet);
        bullet1.transform.position = ShootL.transform.position;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5, 0);
        GameObject bullet2 = Instantiate(ExplosiveBullet);
        bullet2.transform.position = ShootR.transform.position;
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5, 0);
    }

}
