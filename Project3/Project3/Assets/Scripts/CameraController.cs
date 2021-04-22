﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        transform.position = target.GetComponent<Transform>().position - new Vector3(0,0,1);
    }
}
