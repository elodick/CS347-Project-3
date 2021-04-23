using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chaser : EnemyController
{

    public float attackRange;
    public float lungeDelay;
    public float distanceToPlayer;
    public bool positionFound;
    public Vector3 playerPosition;
    public bool startedAttack;
    public float lungeDistance;
    private Vector3 direction;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        AIUpdate();
    }

    override protected void FixedUpdate()
    {
        base.FixedUpdate();
        lungeDelay -= Time.deltaTime;
    }

    private void AIUpdate()
    {

        // Set positions of player and snake
        var playerPosition = playerTransform.position;
        var selfPosition = selfTransform.position;

        // Calculate distance between player and snake
        distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);

        if (distanceToPlayer <= aggroDistance && distanceToPlayer >= attackRange && !startedAttack)
        {
            behavior = Behavior.MOVE;
            Movement();
        }
        if (distanceToPlayer <= attackRange && !startedAttack)
        {
            startedAttack = true;
        } 
        if (startedAttack)
        {
            behavior = Behavior.IDLE;
            Attack();
        }
    }

    // Movement for the snake, change to appropriate sprite and have snake "chase" player. 
    public void Movement()
    {
        speed = 5;
        Vector2 oldLocation = transform.position;
        Vector2 newLocation = oldLocation;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        newLocation = transform.position;
    }

    public void Attack()
    {
        speed = 0;
        if (!positionFound)
        {
            lungeDelay = 0.5f;
        }
        if (lungeDelay >=  0.4 && !positionFound)
        {
            playerPosition = playerTransform.position;
            direction = transform.position - playerPosition;
            direction *= -lungeDistance;
            positionFound = true;
        }

        if (lungeDelay <= 0)
        {
            behavior = Behavior.ATTACK;
        }

        if (behavior == Behavior.ATTACK && positionFound)
        {
            speed = 30;
            Vector2 oldLocation = transform.position;
            Vector2 newLocation = oldLocation;
            transform.position = Vector2.MoveTowards(transform.position, playerPosition+direction, speed * Time.deltaTime);
            if (lungeDelay < -0.5)
            {
                startedAttack = false;
                positionFound = false;
            }
        }
    }

}

