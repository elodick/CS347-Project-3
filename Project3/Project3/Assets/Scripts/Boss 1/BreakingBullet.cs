using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Bullet;
    

    public float RemainingDuration;

    [SerializeField]
    public bool test;

    [SerializeField]
    public float Duration;

    [SerializeField]
    public float PreExplosion, AfterExplosion; // Speed of projectiles

   [SerializeField]
    Transform Top, Bottom, Left, Right, TopRight, TopLeft, BottomLeft, BottomRight;


    void Start()
    {
        RemainingDuration = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(RemainingDuration <= 0)
        {
            test = true;
            Blowup();
        }
    }
    private void FixedUpdate()
    {
        RemainingDuration -= Time.deltaTime;
    }
    private void Blowup()
    {
       
        GameObject bullet1 = Instantiate(Bullet);   //Top 
        bullet1.transform.position = Top.transform.position;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, AfterExplosion, 0);

        GameObject bullet2 = Instantiate(Bullet); //Bottom
        bullet2.transform.position = Bottom.transform.position;
        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -AfterExplosion, 0);

        GameObject bullet3 = Instantiate(Bullet); //Left
        bullet3.transform.position = Left.transform.position;
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector3(-AfterExplosion, 0, 0);

        GameObject bullet4 = Instantiate(Bullet); //Right
        bullet4.transform.position = Right.transform.position;
        bullet4.GetComponent<Rigidbody2D>().velocity = new Vector3(AfterExplosion, 0, 0);

        GameObject bullet5 = Instantiate(Bullet); //TopLeft
        bullet5.transform.position = TopLeft.transform.position;
        bullet5.GetComponent<Rigidbody2D>().velocity = new Vector3(-AfterExplosion, AfterExplosion, 0);

        GameObject bullet6 = Instantiate(Bullet); // TopRight
        bullet6.transform.position = TopRight.transform.position;
        bullet6.GetComponent<Rigidbody2D>().velocity = new Vector3(AfterExplosion, AfterExplosion, 0);

        GameObject bullet7 = Instantiate(Bullet); // BottomLeft
        bullet7.transform.position = BottomLeft.transform.position;
        bullet7.GetComponent<Rigidbody2D>().velocity = new Vector3(-AfterExplosion, -AfterExplosion, 0);

        GameObject bullet8 = Instantiate(Bullet); //BottomRight
        bullet8.transform.position = BottomRight.transform.position;
        bullet8.GetComponent<Rigidbody2D>().velocity = new Vector3(AfterExplosion, -AfterExplosion, 0);
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Blowup();
        }
    }
}
