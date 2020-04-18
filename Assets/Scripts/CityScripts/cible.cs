using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cible : MonoBehaviour
{
    public int triggered = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Renderer>().material.color == Color.blue)
        {
            triggered = 1;
        }
    }
}
