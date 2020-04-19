﻿using UnityEngine;
public class Switch_Camera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void Start()
    {

        cam1.enabled = true;
        cam2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}