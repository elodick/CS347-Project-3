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

    private SpriteRenderer spriteRenderer;

    public int health;

    public float speed;
    public float aggroDistance;
    public float firingSpeed;
    public float cooldown;
    public float timer;
    public int weight;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        selfTransform = GetComponent<Transform>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual protected void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            spriteRenderer.color = new Color(1, 1, 1, 1);
        if (health <= 0)
            Destroy(gameObject);
        Aggro();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
        }

        if (collision.gameObject.CompareTag("playerbullet"))
        {
            timer = 0.1f;
            spriteRenderer.color = new Color(1, 0, 0, 1);
            health -=2 ;
        }

        if (collision.gameObject.CompareTag("playerpellet"))
        {
            timer = 0.1f;
            spriteRenderer.color = new Color(1, 0, 0, 1);
            health -= 1;
        }
    }

    void Aggro()
    {
        var selfPosition = selfTransform.position;
        var playerPosition = playerTransform.position;
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);
        if (distanceToPlayer <= aggroDistance)
        {
            behavior = Behavior.ATTACK;
        }
    }
}
