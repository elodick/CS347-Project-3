using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

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
    }

    void FixedUpdate()
    {
        
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