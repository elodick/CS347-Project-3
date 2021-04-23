using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles all generic attributes of the enemies, as well as their drops.  The enemies on their death (OnDestroy) select from a uniform distribution in order
 * to decide what to drop. Only the enemies that are spawned (canDrop = true) drop anything once destroyed. */ 
public class EnemyController : MonoBehaviour
{
    public enum Behavior { IDLE, ATTACK, MOVE };
    protected GameObject player;
    protected Transform playerTransform;
    protected Transform selfTransform;
    public Behavior behavior;

    private SpriteRenderer spriteRenderer;

    public int health;
    public bool canDrop;
    public float speed;
    public float aggroDistance;
    public float firingSpeed;
    public float cooldown;
    public float timer;
    public int weight;

    // Set these GameObjects in the hierarchy to determine the prefabs to use for drops.
    public GameObject healthdrop, damageReducdrop, bombdrop, laserdrop, shotgundrop, invincdrop, damageUpdrop, speedupdrop, firingspeedupdrop;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        selfTransform = GetComponent<Transform>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        canDrop = false;
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
            health -= player.GetComponent<PlayerController>().damageDealt;
        }

        if (collision.gameObject.CompareTag("bomb"))
        {
            Destroy(gameObject);
        }
    }

    void Aggro()
    {
        var selfPosition = selfTransform.position;
        var playerPosition = playerTransform.position;
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);
        if (distanceToPlayer <= aggroDistance)
        {
            canDrop = true;
            behavior = Behavior.ATTACK;
        }
    }

    private void OnDestroy()
    {
        if (canDrop)
        {
            var itemToDrop = Random.Range(0, 8);
            switch (itemToDrop)
            {
                case 0:
                    Instantiate(healthdrop, transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(damageReducdrop, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(bombdrop, transform.position, transform.rotation);
                    break;
                case 3:
                    break;
                case 4:
                    Instantiate(shotgundrop, transform.position, transform.rotation);
                    break;
                case 5:
                    Instantiate(invincdrop, transform.position, transform.rotation);
                    break;
                case 6:
                    Instantiate(damageUpdrop, transform.position, transform.rotation);
                    break;
                case 7:
                    Instantiate(speedupdrop, transform.position, transform.rotation);
                    break;
                case 8:
                    Instantiate(firingspeedupdrop, transform.position, transform.rotation);
                    break;

            }
        }
    }
}
