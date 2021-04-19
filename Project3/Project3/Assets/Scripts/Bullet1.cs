using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : EnemyProjectileController
{

	float moveSpeed = 7f;

	Rigidbody2D rb;

	GameObject target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.Find("Player");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
	}

    
}
