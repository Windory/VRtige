using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mountain_stat : MonoBehaviour
{
    public bool finished = false;
    public int temps;
    public float temps_debut;
    public float temps_fin;
    public GameObject trigger;
    public Text Congratulation;
    // Start is called before the first frame update
    void Start()
    {
        temps_debut = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<trigger_see>().trigger_end && !finished)
        {
            temps_fin = Time.time;
            temps = (int)(temps_fin - temps_debut);
            finished = true;
            Congratulation.text = "Félicitation vous avez réussi le niveau ! \n              Temps : " + temps.ToString() + " secondes";
        }
    }
}
