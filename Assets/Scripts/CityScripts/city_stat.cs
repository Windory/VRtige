using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace city
{
    public class city_stat : MonoBehaviour
    {
        public bool finished = false;
        public int temps;
        public float temps_debut;
        public float temps_fin;
        public GameObject checkpoint;
        // Start is called before the first frame update
        void Start()
        {
            temps_debut = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (checkpoint.GetComponent<change_location>().checkpoint == 10 && !finished)
            {
                temps_fin = Time.time;
                temps = (int)(temps_fin - temps_debut);
                finished = true;
            }
        }
    }
}
