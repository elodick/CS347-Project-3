using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum Behavior { IDLE, ATTACK, MOVE };
    protected GameObject player;
    protected Transform playerTransform;
    protected Transform selfTransform;
    public Behavior behavior;


    public int health;

    public float speed;
    public float aggroDistance;
    public float firingSpeed;
    public float cooldown;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        selfTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
        }
    }
}
