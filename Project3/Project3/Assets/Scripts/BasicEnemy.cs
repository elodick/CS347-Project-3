using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject bulletPrefab;

    [SerializeField]
    public float bulletForce = 20f;

    public int Health;
    public float AttackDelay = 3f;

    public float AttackTime;

    private bool shootDir;
    void Start()
    {
        AttackTime = AttackDelay;    
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(AttackTime <=0)
        {
            if (shootDir == true)
            {
                shootDir = false;
            }
            else
            {
                shootDir = true;
            }
            Shoot(shootDir);
            AttackTime = AttackDelay;
        }
    }
    private void Shoot(bool shootDir)
    {
        if(shootDir == true)
        {

        }
        else
        {

        }
    }
    
}
