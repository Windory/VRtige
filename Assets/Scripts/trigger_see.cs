using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class trigger_see : MonoBehaviour
{
    public int numberOfTargets = 0;
    public int targetCount = 0;
    public Text Congratulation;
    private GameObject[] numbertarget;

    void Start()
    {
        Congratulation.gameObject.SetActive(false);
        numbertarget = GameObject.FindGameObjectsWithTag("Cible");
        numberOfTargets = numbertarget.Length;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && hit.transform.tag == "Cible" && hit.collider.gameObject.GetComponent<Renderer>().material.color != Color.green)
        {
            //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
            if(hit.collider.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                targetCount++;
            }
        }
        if (targetCount == numberOfTargets)
        {
            Congratulation.gameObject.SetActive(true);
        }

    }
}