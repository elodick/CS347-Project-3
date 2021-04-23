using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the behavior of the robot enemy that shoots in an expanding circle. 
   This script uses a uniform distribution to change a random number of projectiles to shoot per pulse */
public class Enemy_spiralshooter : EnemyController
{
    // The enemy_projectile GameObject is the prefab to use for the enemy's bullets
    public GameObject enemy_projectile;

    // Number of projectiles to shoot per pulse
    public int numberOfProjectiles;

    // Radius of the circle the shots travel in
    public float radius;

    // The current position of the enemy
    Vector3 selfPosition;

    // The movement speed of the projectiles
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        selfPosition = selfTransform.position;
    }

    // Find a random number from 4-36, cast it to an int, and return that value
    int getNumberOfProjectiles()
    {
        var result = Random.Range(4, 8);
        return (int)result;
    }
    // Update is called once per frame
    void Update()
    {
        // Enemy constantly checks if it is able to attack
        Aggro();

        // If it is knocked to 0 or less health, it is destroyed
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    override protected void FixedUpdate()
    {
        // Firingspeed is a running timer to determine time between attacks. At 0 or < 0 the enemy can attack.
        firingSpeed -= Time.deltaTime;
        base.FixedUpdate();
    }

    // The enemy checks its position relative to the player's position.  If it is within distance, and is able to fire, it attacks and its firingSpeed is reset. 
    private void Aggro()
    {
        var playerPosition = playerTransform.position;
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);
        if (distanceToPlayer <= aggroDistance && firingSpeed <= 0)
        {
            Attack();
            firingSpeed = cooldown;
        }
    }

    // Attack function for this enemy, the number of projectiles is divided into 360 degrees determining their launch angle and direction. 
    private void Attack()
    {
        numberOfProjectiles = getNumberOfProjectiles();
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectile_DirectionX = selfPosition.x + Mathf.Sin((angle * Mathf.PI)/180 * radius);
            float projectile_DirectionY = selfPosition.y + Mathf.Cos((angle * Mathf.PI)/180 * radius);

            var projectileMoveVector = new Vector3(projectile_DirectionX, projectile_DirectionY, 0);
            var projectileDirection = (projectileMoveVector - selfPosition).normalized * moveSpeed;

            var projectile = Instantiate(enemy_projectile, selfPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileDirection.x, projectileDirection.y);
            angle += angleStep;
        }
    }
}
