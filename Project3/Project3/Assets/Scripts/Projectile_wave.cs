using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_wave : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("playerbullet"))
        {
            Destroy(gameObject);
        }
    }
}
