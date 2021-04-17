using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour //Bullets that the enemies are firing
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hit, 5f);
        Destroy(gameObject);
        */ 
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

        }
    }
}
