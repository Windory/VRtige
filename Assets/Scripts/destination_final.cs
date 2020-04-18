using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destination_final : MonoBehaviour
{
    public Collider Player;
    bool showGUI = false;

    [SerializeField]
    private Text objectif;
    // Start is called before the first frame update
    void Start()
    {
        objectif.gameObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player"))
        {
            Debug.Log("Hi !");
            showGUI = true;
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.CompareTag("Player"))
        {
            Debug.Log("Bye !");
            showGUI = false;
            objectif.gameObject.gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if(showGUI)
        {
            objectif.gameObject.gameObject.SetActive(true);
            //objectif.text = "Fixez les 3 objets jaunes se situant dans le vide!";
            //GUI.contentColor = Color.green;
            //GUI.Label(new Rect(500, 200, 300, 500), "Fixez les 3 objets jaunes se situant dans le vide!");
        }
        
    }
}
