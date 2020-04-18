using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_location : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider objet_collision)
    {
        if (objet_collision.GetComponent<Collider>().name == "Player")
        {
            sphere.transform.position += new Vector3(10, 0, 0);
        }
    }
}
