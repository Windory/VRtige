﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_objectif : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {

        }
    }
}