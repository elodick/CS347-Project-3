using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Main : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    bool Phase1, Phase2;

    [SerializeField]
    bool MoveL, MoveR;

    [SerializeField]
    bool Attack;

    [SerializeField]
    GameObject Boss, player;

    [SerializeField]
    public float health, p2Health;

    [SerializeField]
    public float Speed, BaseMoveTime, BaseAttackTime; //Speed and duration of each move

    public float MoveTime, AttackTime;


    [SerializeField]
    public float BaseBdelay, BaseShootDuration; //Fire rate and duration bullets are fired for

    public float Bdelay, ShootDuration;

    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Sprite P1Sprite, P2Sprite, P3Sprite;

    public Boss1_Attack BossA;

    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer.sprite = P1Sprite;
        MoveR = true;
        Phase1 = true;
        Phase2 = false;
        p2Health = health / 2.3f; // Health needed to start phase2 
        MoveTime = BaseMoveTime;
        Bdelay = BaseBdelay;
        ShootDuration = BaseShootDuration;


    }

    void FixedUpdate()
    {

        //  MoveTime -= Time.deltaTime;
        AttackTime -= Time.deltaTime;

        Bdelay -= Time.deltaTime;
        ShootDuration -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        if (Phase1) // Start Phase 1 actions
        {
            //Start_P1();


        }
        if (Phase2) // Start Phase 2 actions
        {
            spriteRenderer.sprite = P2Sprite;
        }




        if (Bdelay < -3) // Reset Move Time and swap move directions
        {
            Bdelay = BaseBdelay;

        }

        if (ShootDuration < 0)
        {
            ShootDuration = BaseShootDuration;
        }



        if (health <= p2Health)//Enter third stage if below or equal health threshold
        {
            Phase1 = false;
            Phase2 = true;
            if (Speed == 0.1f)
            {
                Speed += 0.1f;
                BaseMoveTime -= 1f;
            }
        }
        /*
        if (MoveTime <= 0 ) // Reset Move Time and swap move directions
        {
            MoveTime = BaseMoveTime;
            MoveSwap(); 
        }
        */
        if (AttackTime <= 0) // Reset Move Time and swap move directions
        {
            AttackTime = BaseAttackTime;
            AttackRandom();
        }




        if (MoveR)
        {
            //Move Right

            transform.position += new Vector3(Speed, 0, 0);

        }
        if (MoveL)
        {
            //Move Left
            transform.position += new Vector3(-Speed, 0, 0);
        }
    }

    public void MoveSwap()// function to swap movement directions; 
    {
        if (MoveR == true)
        {
            MoveR = false;
            MoveL = true;
            return;

        }
        if (MoveL == true)
        {
            MoveL = false;
            MoveR = true;
            return;
        }
    }

    private void AttackRandom()
    {
        if (Phase1)
        {
            int x = Random.Range(1, 21);    //Uniform dist for boss attacks
            if (x < 15)
            {
                Boss.GetComponent<Boss1_Attack>().ShootBullets();
            }
            if (x >= 15)
            {
                Boss.GetComponent<Boss1_Attack>().SpawnEnemies();
            }

        }
        if (Phase2)
        {
            int x = Random.Range(1, 21); //Uniform dist for boss attacks
            if (x < 7)
            {
                Boss.GetComponent<Boss1_Attack>().ShootBullets();
            }
            if (x > 7 && x < 14)
            {
                Boss.GetComponent<Boss1_Attack>().SpawnEnemies();
            }
            if (x > 14)
            {
                Boss.GetComponent<Boss1_Attack>().ShootExplosion();
            }
        }


    }
    private void Die()
    {
       
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (MoveL)
            {
                MoveL = false;
                MoveR = true;
                return;
            }
            if (MoveR)
            {
                MoveL = true;
                MoveR = false;
                return;
            }
        }
        if (collision.gameObject.CompareTag("playerbullet"))
        {

            health -= player.GetComponent<PlayerController>().damageDealt;
            if(MoveL)
            {
                MoveL = false;
                MoveR = true;
                return;
            }
            if (MoveR)
            {
                MoveL = true;
                MoveR = false;
                return;
            }
        }
    }
}
