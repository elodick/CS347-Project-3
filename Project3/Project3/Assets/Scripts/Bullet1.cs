using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour {

	float moveSpeed = 7f;

	Rigidbody2D rb;

	Player target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindObjectOfType<Player>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Hit!");
			Destroy(gameObject);


		}

		if (collision.gameObject.CompareTag("Wall"))
		{
			Debug.Log("Hit!");
			Destroy(gameObject);


		}
	}
}
