using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    //public GameObject hitEffect;

    [SerializeField]
    public float duration;

    public float remainingTime;
    private void Start()
    {
        duration = 2.2f;
        remainingTime = duration;
    }
    private void FixedUpdate()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hit, 5f);
        Destroy(gameObject);
        */
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);

        }
    }
}