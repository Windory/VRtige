using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace city
{
    public class text_UI : MonoBehaviour
    {
        public int sphere_vues = 0;
        public Text sphere_UI;
        public GameObject checkpoint;
        public GameObject cible1;
        public GameObject cible2;
        public GameObject cible3;
        public string objectif = "Objectif : Traversez le pont";
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            sphere_vues = cible1.GetComponent<cible>().triggered + cible2.GetComponent<cible>().triggered + cible3.GetComponent<cible>().triggered;
            if (checkpoint.GetComponent<change_location>().checkpoint == 5)
            {
                objectif = "Objectif : Regardez les sphères \nSphères : " + sphere_vues.ToString() + "/3";
            }
            if (sphere_vues == 3)
            {
                cible1.gameObject.SetActive(false);
                cible2.SetActive(false);
                cible3.SetActive(false);
                checkpoint.SetActive(true);
                objectif = "Objectif : Traversez le pont";
            }
            if (checkpoint.GetComponent<change_location>().checkpoint == 10)
            {
                objectif = "Félicitation ! \nTemps : " + this.GetComponent<city_stat>().temps.ToString() + " secondes";
                cible1.GetComponent<cible>().triggered = 0;
            }
            sphere_UI.text = objectif;
        }
    }
}