using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace city
{
    public class change_location : MonoBehaviour
    {
        public GameObject sphere;
        public int checkpoint = 0;
        public GameObject cible1;
        public GameObject cible2;
        public GameObject cible3;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (checkpoint == 4)
            {
                cible1.SetActive(true);
                cible2.SetActive(true);
                cible3.SetActive(true);
                gameObject.SetActive(false);
                checkpoint += 1;
            }

            if (checkpoint == 10)
            {
                gameObject.SetActive(false);
            }
        }

        void OnTriggerEnter(Collider objet_collision)
        {
            if (objet_collision.GetComponent<Collider>().name == "Player")
            {
                sphere.transform.position += new Vector3(3, 0, 0);
                checkpoint += 1;
            }
        }
    }
}