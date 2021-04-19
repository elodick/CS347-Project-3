using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange; 

    [SerializeField]
    float speed;

    Rigidbody2D rb;

    [SerializeField]
    int health; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 4; 
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        
        if(distanceToPlayer <= agroRange) //Chase Player
        {
            ChasePlayer();
        }
        else //Dont Chase
        {
            stopChasing();
        }
        if (health <= 0)
        {
            death(); 
        }
    }
    private void ChasePlayer()
    {
        speed = 5;
        Vector2 oldLocation = transform.position;
        Vector2 newLocation = oldLocation;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        newLocation = transform.position;
    }
    private void stopChasing()
    {

    }
    private void death()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }

    }
}
