using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spiralshooter : EnemyController
{
    // Start is called before the first frame update
    public GameObject enemy_projectile;
    public int numberOfProjectiles;
    public float radius;
    Vector3 selfPosition;
    public float moveSpeed = 1f;

    override protected void Start()
    {
        base.Start();
        selfPosition = selfTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Aggro();
    }

    private void FixedUpdate()
    {
        firingSpeed -= Time.deltaTime;
    }
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

    private void Attack()
    {
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
