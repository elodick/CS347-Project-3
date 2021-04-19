using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health;
    private float timer;
    SpriteRenderer spriteRenderer;

    public Rigidbody2D rb;
    public Camera cam;
    public float angle;
    public Vector2 mouse;
    // Start is called before the first frame update
    void Start()
    {

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
            health--;
        }
    }
}
