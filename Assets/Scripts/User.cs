/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
namespace test2logpa8
{
    public class User
    {

        public bool login(String id, String pwd)
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
    }
}*/