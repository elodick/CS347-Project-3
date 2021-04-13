using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

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
        Vector2 lookdir = mouse - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void MoveRight()
    {
        transform.position += new Vector3(moveSpeed, 0, 0);

    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0);

    }

    private void MoveDown()
    {
        transform.position += new Vector3(0, -moveSpeed, 0);

    }

    private void MoveUp()
    {
        transform.position += new Vector3(0, moveSpeed, 0);

    }
}
