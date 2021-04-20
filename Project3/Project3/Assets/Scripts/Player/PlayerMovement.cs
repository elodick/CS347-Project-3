using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    private  float speed;
    Vector2 mouse;

    // Update is called once per frame
    void Update()
    {
        var rightIsPressed = Input.GetKey(KeyCode.D);
        var leftIsPressed = Input.GetKey(KeyCode.A);
        var downIsPressed = Input.GetKey(KeyCode.S);
        var upIspressed = Input.GetKey(KeyCode.W);

        if (rightIsPressed)
            MoveRight();
        if (leftIsPressed)
            MoveLeft();
        if (downIsPressed)
            MoveDown();
        if (upIspressed)
            MoveUp();
        
        
        mouse = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        speed = GetComponent<PlayerController>().moveSpeed;
        Vector2 lookdir = mouse - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void MoveRight()
    {
        transform.position += new Vector3(speed, 0, 0);

    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-speed, 0, 0);

    }

    private void MoveDown()
    {
        transform.position += new Vector3(0, -speed, 0);

    }

    private void MoveUp()
    {
        transform.position += new Vector3(0, speed, 0);

    }

}