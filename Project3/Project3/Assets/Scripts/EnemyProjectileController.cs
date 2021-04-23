using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls overall behavior for the enemy projectile.  This script directs all enemy projectiles to have a lifetime of 5.0f before they are destroyed, and that they are
// destroyed upon impact with the walls, the player, or their bullets. 
public class EnemyProjectileController : MonoBehaviour
{
    private float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("playerbullet"))
        {
            Destroy(gameObject);
        }
    }
}
