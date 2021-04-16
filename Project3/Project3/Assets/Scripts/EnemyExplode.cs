using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(hit, 5f);
        Destroy(gameObject);
    }
}
