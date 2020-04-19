using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

public class User : MonoBehaviour
{
    private string pseudo = "";

    public bool login(string id, string pwd)
    {
        var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
        var database = client.GetDatabase("VRTIGE");
        var collection = database.GetCollection<BsonDocument>("VR");
        var filter = Builders<BsonDocument>.Filter.Eq("nom utilisateur", id) & Builders<BsonDocument>.Filter.Eq("pwd", pwd);
        var result = collection.Find(filter).ToList();
        if (result.Count != 0)
        {
            pseudo = id;
            return true;
        }
        return false;
    }

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

    public bool create_profile_light(string nom, string prenom, string pseudo, string pwd)
    {
        return create_profile(nom, prenom, pseudo, pwd, "", "null");
    }

    public BsonDocument consulter_stats()
    {
        try
        {
            var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
            var database = client.GetDatabase("VRTIGE");
            var collection = database.GetCollection<BsonDocument>("VR");
            var filter = Builders<BsonDocument>.Filter.Eq("nom utilisateur", pseudo);
            var result = collection.Find(filter).ToList();

            if (result.Count == 0)
                return null; // informations incorrectes

            foreach (var doc in result)
            {
                Debug.Log(doc.GetElement(0));
            }
            return result[0];
        }
        catch (Exception e)
        {
            return null;
        }
    }
}