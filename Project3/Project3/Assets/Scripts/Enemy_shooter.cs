using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooter : EnemyController {

	[SerializeField]
	GameObject bullet;

	float fireRate;
	float nextFire;

	// Use this for initialization
	override protected void Start () {
		base.Start();
		fireRate = 1f;
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfTimeToFire ();
	}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void CheckIfTimeToFire()
	{
		if (behavior == Behavior.ATTACK)
		{
			if (Time.time > nextFire)
			{
				Instantiate(bullet, transform.position, Quaternion.identity);
				nextFire = Time.time + fireRate;
			}
		}
	}

}
