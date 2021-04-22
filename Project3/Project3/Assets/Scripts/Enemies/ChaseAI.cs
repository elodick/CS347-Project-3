using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : EnemyController
{
    // Start is called before the first frame update
    [SerializeField]
    Transform Player;


    Rigidbody2D rb;

    override protected void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        
        if(behavior == Behavior.ATTACK) //Chase Player
        {
            ChasePlayer();
        }
        else //Dont Chase
        {
            stopChasing();
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
}
