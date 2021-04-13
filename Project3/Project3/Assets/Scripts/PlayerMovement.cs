using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed =0.01f;

    [SerializeField]
    public float bulletSpeed = 40f;

    [SerializeField]
    Transform B_PlacementL; //Placement of bullet firing if facing left

    [SerializeField]
    Transform B_PlacementR;

    [SerializeField]
    Transform B_PlacementU; //Placement of bullet firing if facing up

    [SerializeField]
    Transform B_PlacementD;

    [SerializeField]
    GameObject Bullet;

    private char direction; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement Directions
        var rightIsPressed = Input.GetKey(KeyCode.D);
        var leftIsPressed = Input.GetKey(KeyCode.A);
        var downIsPressed = Input.GetKey(KeyCode.S);
        var upIspressed = Input.GetKey(KeyCode.W);
        // Shooting directions
        var ShootUp = Input.GetKeyDown(KeyCode.UpArrow);
        var ShootRight = Input.GetKeyDown(KeyCode.RightArrow);
        var ShootLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        var ShootDown = Input.GetKeyDown(KeyCode.DownArrow);
        if (rightIsPressed)
        {
            MoveRight();
        }
        // Called when Left key is Pressed
        if (leftIsPressed)
        {
            MoveLeft();
        }

        if (downIsPressed)
        {
            MoveDown();
        }

        if (upIspressed)
        {
            MoveUp();
        }
        if (ShootRight)
        {
            direction = 'r';
            playerShoot(direction);
        }
        // Called when Left key is Pressed
        if (ShootLeft)
        {
            direction = 'l';
            playerShoot(direction);
        }

        if (ShootDown)
        {
            direction = 'd';
            playerShoot(direction);
        }

        if (ShootUp)
        {
            direction = 'u';
            playerShoot(direction); 
        }
    }

    private void MoveRight()
    {
        transform.position += new Vector3(MoveSpeed, 0, 0);

    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-MoveSpeed, 0, 0);

    }

    private void MoveDown()
    {
        transform.position += new Vector3(0, -MoveSpeed, 0);

    }

    private void MoveUp()
    {
        transform.position += new Vector3(0, MoveSpeed, 0);

    }
    private void playerShoot(char dir)
    {
        //Ammo--;
        GameObject b = Instantiate(Bullet);

        if(dir == 'l')
        {
            b.transform.position = B_PlacementL.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        }
        if (dir == 'r')
        {
            b.transform.position = B_PlacementR.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        }
        if (dir == 'u')
        {
            b.transform.position = B_PlacementU.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
        }
        if (dir == 'd')
        {
            b.transform.position = B_PlacementD.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
        }
    }
}
