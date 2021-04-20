using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Store current camera's position
        Vector3 temp = transform.position;

        // setting the x value of camera's position to the player's x and y position
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        // setting the 
        transform.position = temp;

        

    }

} 
