using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace city
{
    public class trigger_see : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && hit.transform.tag == "Cible")
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
