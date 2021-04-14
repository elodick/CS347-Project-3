using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected enum Behavior { IDLE, ATTACK, MOVE };
    protected GameObject player;
    protected Transform playerTransform;
    protected Transform selfTransform;
    protected Behavior behavior;


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
}
