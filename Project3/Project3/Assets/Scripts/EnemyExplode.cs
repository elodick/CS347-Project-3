using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode: MonoBehaviour
{
    public Animator animator;
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Explode");
            collision.gameObject.GetComponent<Heart_Manage>().Health -= damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.ResetTrigger("Explode");
    }
}
