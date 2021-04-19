using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyChase : MonoBehaviour
{
    
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private Transform target;
    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotation * rotationSpeed;
        rb.velocity = transform.up * speed;
    }
}
