using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int health, MaxHealth;
    public float timer, shieldtimer, bombtimer;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Text PickupMes, CurrentWeapon, Display_Damage, Display_FireRate, Display_MoveSpeed;

    [SerializeField]
    public float MSBaseTime, MessageTimer;


    private string
    bdam = "Damage: ", bfir = "FireRate: ", bmov = "MoveSpeed: ";


    public GameObject invincibleShield, bomb;

    public Rigidbody2D rb;
    public Camera cam;
    public float angle;
    public Vector2 mouse;
    private bool invulnerable;
    public float moveSpeed, firingSpeed; //movement speed and firing speed. The lower the firing speed the faster the player can shoot
    public int shotType, damageReceived, damageDealt; //ShotType is weapons
    // Start is called before the first frame update
    void Start()
    {
        firingSpeed = 0.25f;
        damageDealt = 2;
        damageReceived = 2;
        health = MaxHealth;
        moveSpeed = 0.1f;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        shotType = 0;
        
    }

    private void Awake()
    {
         DontDestroyOnLoad(transform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        if (MessageTimer < 0)
        {
            PickupMes.text = "";
        }
        if(shotType == 0)
            {
            CurrentWeapon.text = "Current Weapon: Normal";
             }
        if (shotType == 1)
        {
            CurrentWeapon.text = "Current Weapon: Shotgun";
        }
        if (shotType == 2)
        {
            CurrentWeapon.text = "Current Weapon: FlameThrower";
        }
        DisplayStats();
    }
    private void FixedUpdate()
    {
        //if (health <= 0)
            //SceneManager.LoadScene("SampleScene");
        timer -= Time.deltaTime;
        shieldtimer -= Time.deltaTime;
        bombtimer -= Time.deltaTime;
        if (timer <= 0)
            spriteRenderer.color = new Color(1, 1, 1, 1);
        Vector2 lookdir = mouse - rb.position;
        angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if(MessageTimer >=0)
        {
            MessageTimer -= Time.deltaTime;
        }

        if (shieldtimer <= 0)
        {
            invincibleShield.SetActive(false);
            invulnerable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("projectile") && !invulnerable)
        {
            timer = 0.2f;
            spriteRenderer.color = new Color(1, 0, 0, 1);
            health -= damageReceived;
        }
        if (collision.gameObject.CompareTag("drop"))
        {
            var dropType = collision.gameObject.GetComponent<DropController>().dropType;

            switch (dropType)
            {
                case 0:
                    MaxHealth += 1;
                    DisplayAcquired("Health increased");
                    break;
                case 1:
                    if(damageReceived == 1)
                    {
                        //Because damage recieved can't be below 1, this could instead call temporary invincibilty;

                        break;
                    }
                    DisplayAcquired("Damage Reduction");
                    damageReceived -= 1;
                    
                    break;
                case 2:
                    break;
                case 3:
                    DisplayAcquired("Flame Thrower!");
                    shotType = 1;
                    break;
                case 4:
                    shotType = 1;
                    GetComponent<Shoot>().numOfSpread++;
                    DisplayAcquired("Spread Shot!");
                    break;
                case 5:
                    shieldtimer = 5.0f;
                    invincibleShield.SetActive(true);
                    invulnerable = true;
                    DisplayAcquired("Temporary Invincibility");
                    break;
                case 6:
                    damageDealt++;
                    DisplayAcquired("Damage Increased!");
                    break;
                case 7:
                    moveSpeed += 0.05f;
                    DisplayAcquired("Increased MoveSpeed!");
                    break;
                case 8:
                    DisplayAcquired("Increased FireRate!");
                    firingSpeed -= 0.1f;
                    break;
            }
        }

        if (collision.gameObject.CompareTag("bomb"))
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
        }
    }
    public void DisplayAcquired(string mes)
    {
        MessageTimer = MSBaseTime;
        PickupMes.text = mes;
    }
    public void DisplayStats()
    {
        Display_Damage.text = bdam +damageDealt;
        Display_FireRate.text = bfir +firingSpeed; 
        Display_MoveSpeed.text = bmov+moveSpeed;
    }
}
