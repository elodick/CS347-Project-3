using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_wave : EnemyProjectileController
{
    public float frequency = 2;
    public float amplitude = 2;
    public float speed = 1;

    // Start is called before the first frame update

    private Rigidbody2D projectilebody;
    private float lifetime;
    private Vector2 direction;
    void Start()
    {
        projectilebody = GetComponent<Rigidbody2D>();
        direction = transform.right; 
        direction.Normalize(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
