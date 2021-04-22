using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    // Start is called before the first frame update
    public int dropType, bombsize;
    private float bombtimer;
    private int scale;
    void Start()
    {
        scale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        bombtimer -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (dropType != 2)
                Destroy(gameObject);
            else
            {
                gameObject.layer = LayerMask.NameToLayer("playerbullets");
                gameObject.tag = "bomb";
                InvokeRepeating("BombExplode", 0f, 0.1f);
            }
        }
    }

    void BombExplode()
    {
        scale += 1;
        transform.localScale = new Vector3(scale, scale, 0);

        if (scale > bombsize)
            Destroy(gameObject);
    }
}
