using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace test2logpa8
{
    class Profile : MonoBehaviour
    {
        public GameObject loginScreen;
        public GameObject registerScreen;

        public Text loginData;
        public Text pswData;
        public Text confirmPswData;
        public Text nomData;
        public Text prenomData;
        public Text errorLabel;

        public bool create_profile(string nom, string prenom, string pseudo, string pwd, string numsuiv, string therapeute)
        {
            try
            {
                var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
                var database = client.GetDatabase("VRTIGE");
                var collection = database.GetCollection<BsonDocument>("VR");
                var document = new BsonDocument
            {
                {"nom", nom },
                {"prenom", prenom },
                {"nom utilisateur", pseudo },
                {"pwd", pwd },
                {"N° de suivi", numsuiv },
                {"Thérapeute", therapeute }
            };
                collection.InsertOne(document);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SendProfile()
        {
            string nom = nomData.text;
            string prenom = prenomData.text;
            string pseudo = loginData.text;
            string pwd = pswData.text;
            string confirmPwd = confirmPswData.text;

            if (pwd != confirmPwd)
            {
                errorLabel.text = "Erreur : les mots de passe ne correspondent pas";
            }
            else
            {
                if (create_profile(nom, prenom, pseudo, pwd, "0", "null"))
                {
                    loginScreen.SetActive(true);
                    registerScreen.SetActive(false);
                }
                else
                {
                    errorLabel.text = "Erreur : le profile n'a pas pu être créé";
                }
            }
        }
    }
}