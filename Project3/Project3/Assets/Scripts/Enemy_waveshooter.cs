using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_waveshooter : EnemyController
{
    // Start is called before the first frame update
    public GameObject projectile_wave;
    public float amplitude;
    Vector3 selfPosition;
    public float sideSpeed = 1f;
    private Vector2 direction;
    private float lifetime;

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
        lifetime -= Time.deltaTime;
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
        float frequency = 2;
        float amplitude = 2;
        float speed = 1;
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0: 
                    direction = transform.right;
                    break;
                case 1:
                    direction = -transform.right;
                    break;
                case 2:
                    direction = transform.up;
                    break;
                case 3:
                    direction = -transform.up;
                    break;
            }
            var projectile = Instantiate(projectile_wave, selfPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = getVelocity(direction, speed, lifetime, frequency, amplitude);
        }
    }

    private Vector2 getVelocity(Vector2 forward, float speed, float time, float frequency, float amplitude)
    {
        Vector2 up = new Vector2(-forward.y, forward.x);
        float up_speed = Mathf.Cos(time * frequency) * amplitude * frequency;
        return up * up_speed + forward * speed;
    }
}
