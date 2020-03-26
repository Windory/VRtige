using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
namespace test2logpa8
{
    class Profile
    {
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
    }
}

