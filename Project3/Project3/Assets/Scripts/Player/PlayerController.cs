using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int health, MaxHealth;
    private float timer;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Text text;

    public Rigidbody2D rb;
    public Camera cam;
    public float angle;
    public Vector2 mouse;
    public float moveSpeed, firingSpeed;
    public int shotType, damageReceived, damageDealt;
    // Start is called before the first frame update
    void Start()
    {
        firingSpeed = 0.75f;
        damageDealt = 2;
        damageReceived = 2;
        health = MaxHealth;
        moveSpeed = 0.1f;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        //if (health <= 0)
            //SceneManager.LoadScene("SampleScene");
        timer -= Time.deltaTime;
        if (timer <= 0)
            spriteRenderer.color = new Color(1, 1, 1, 1);
        Vector2 lookdir = mouse - rb.position;
        angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("projectile"))
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
                    damageReceived -= 1;
                    break;
                case 2:
                    // destroy all enemies
                    break;
                case 3:
                    shotType = 2;
                    break;
                case 4:
                    shotType = 1;
                    break;
                case 5:
                    // enable invincibility
                    break;
                case 6:
                    damageDealt++;
                    break;
                case 7:
                    moveSpeed += 0.05f;
                    break;
                case 8:
                    firingSpeed -= 0.25f;
                    break;
            }
        }
    }
    public void DisplayAcquired(string mes)
    {
        text.text = mes;
    }
}
