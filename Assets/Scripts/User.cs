using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

public class User : MonoBehaviour
{
    public GameObject loginScreen;
    public GameObject mainMenu;

    public Text loginData;
    public Text pswData;
    public Text errorLabel;

    public bool login(string id, string pwd)
    {
        var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
        var database = client.GetDatabase("VRTIGE");
        var collection = database.GetCollection<BsonDocument>("VR");
        var filter = Builders<BsonDocument>.Filter.Eq("nom utilisateur", id) & Builders<BsonDocument>.Filter.Eq("pwd", pwd);
        var result = collection.Find(filter).ToList();
        if (result.Count != 0)
        {
            return true;
        }
        return false;
    }

    public void SendLogin()
    {
        string id = loginData.text;
        string pwd = pswData.text;

        if (login(id, pwd))
        {
            errorLabel.text = "";
            loginScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            errorLabel.text = "Erreur : identifiants incorrects";
        }
    }
}