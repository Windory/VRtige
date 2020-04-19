using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;

public class StatsManager : MonoBehaviour
{
    private Therapeute therapeute;
    private User user;

    public GameObject statsMenu;
    public GameObject therapeuteMenu;
    public GameObject statsMenuUser;
    public GameObject mainMenu;

    public Text nomData;
    public Text prenomData;
    public Text numData;
    public Text errorLabel;

    public Text outputTherapeute;
    public Text outputUser;

    // Start is called before the first frame update
    void Start()
    {
        therapeute = GetComponent<Therapeute>();
        user = GetComponent<User>();
    }

    public void SendStatsTherapeute()
    {
        string nom = nomData.text;
        string prenom = prenomData.text;
        string num = numData.text;

        outputTherapeute.text = "";

        BsonDocument result = therapeute.consulter_stats(nom, prenom, num);
        if (result != null)
        {
            errorLabel.text = "";
            therapeuteMenu.SetActive(false);
            statsMenu.SetActive(true);
            foreach (var elt in result)
            {
                if (elt.Name != "_id" && elt.Name != "pwd")
                {
                    if (elt.Name == "statistiques")
                    {
                        foreach (var elt2 in elt.Value[0].AsBsonDocument)
                        {
                            outputTherapeute.text += elt2.Value + "\n";
                        }
                    }
                    else
                        outputTherapeute.text += elt.Value + "\n";
                }
            }
        }
        else
        {
            errorLabel.text = "Erreur : informations incorrectes";
        }
    }

    public void SendStatsUser()
    {
        outputUser.text = "";
        BsonDocument result = user.consulter_stats();
        if (result != null)
        {
            errorLabel.text = "";
            mainMenu.SetActive(false);
            statsMenuUser.SetActive(true);
            foreach (var elt in result)
            {
                if (elt.Name != "_id" && elt.Name != "pwd")
                {
                    if (elt.Name == "statistiques")
                    {
                        foreach (var elt2 in elt.Value[0].AsBsonDocument)
                        {
                            outputUser.text += elt2.Value + "\n";
                        }
                    }
                    else
                        outputUser.text += elt.Value + "\n";
                }
            }
        }
    }
}
