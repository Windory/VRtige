using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class Therapeute : MonoBehaviour
{
    public bool create_profile(string nom, string prenom, string pseudo, string pwd)
    {
        try
        {
            var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
            var database = client.GetDatabase("VRTIGE");
            var collection = database.GetCollection<BsonDocument>("Therapeutes");
            var document = new BsonDocument
            {
                {"nom", nom },
                {"prenom", prenom },
                {"nom utilisateur", pseudo },
                {"pwd", pwd },
            };
            collection.InsertOne(document);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool consulter_stats(string nom, string prenom, string numsuiv) // le thérapeute consulte les infos d'un patient en saisissant des infos
    {
        try
        {
            var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
            var database = client.GetDatabase("VRTIGE");
            var collection = database.GetCollection<BsonDocument>("VR");
            var filter = Builders<BsonDocument>.Filter.Eq("nom", nom) & Builders<BsonDocument>.Filter.Eq("prenom", prenom) & Builders<BsonDocument>.Filter.Eq("N° de suivi", numsuiv);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc.ToJson());
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Informations incorrectes");
            return false;
        }
    }

    public bool niveau_et_feedback(string nom, string prenom, string numsuiv, string niv, string feedb) //le thérapeute conseille un niveau et donne son feedback à un patient
    {
        try
        {
            var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
            var database = client.GetDatabase("VRTIGE");
            var collection = database.GetCollection<BsonDocument>("VR");
            var filter = Builders<BsonDocument>.Filter.Eq("nom", nom) & Builders<BsonDocument>.Filter.Eq("prenom", prenom) & Builders<BsonDocument>.Filter.Eq("N° de suivi", numsuiv);
            var update = Builders<BsonDocument>.Update.Set("niveau conseillé", niv);
            var update2 = Builders<BsonDocument>.Update.Set("feedback", feedb);
            collection.UpdateOne(filter, update);
            collection.UpdateOne(filter, update2);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("La mise à jour des données a échoué");
            return false;
        }
    }
    public bool login(String id, String pwd)
    {
        var client = new MongoClient("mongodb+srv://alou:ffpkWFqu5GHuWgo6@vrclust-tlgid.mongodb.net/vrtige?retryWrites=true&w=majority");
        var database = client.GetDatabase("VRTIGE");
        var collection = database.GetCollection<BsonDocument>("Therapeutes");
        var filter = Builders<BsonDocument>.Filter.Eq("nom utilisateur", id) & Builders<BsonDocument>.Filter.Eq("pwd", pwd);
        var result = collection.Find(filter).ToList();
        if (result.Count != 0)
        {
            return true;
        }
        return false;
    }
}

