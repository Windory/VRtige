using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    private Therapeute therapeute;

    public GameObject statsMenu;
    public GameObject therapeuteMenu;

    public Text nomData;
    public Text prenomData;
    public Text numData;
    public Text errorLabel;

    // Start is called before the first frame update
    void Start()
    {
        therapeute = GetComponent<Therapeute>();
    }

    public void SendStats()
    {
        string nom = nomData.text;
        string prenom = prenomData.text;
        string num = numData.text;

        if (therapeute.consulter_stats(nom, prenom, num))
        {
            errorLabel.text = "";
            therapeuteMenu.SetActive(false);
            statsMenu.SetActive(true);
        }
        else
        {
            errorLabel.text = "Erreur : informations incorrectes";
        }
    }
}
