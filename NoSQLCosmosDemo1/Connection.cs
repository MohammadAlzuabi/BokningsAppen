using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLCosmosDemo1
{
    internal class Connection
    {
        private static MongoClient GetClient()
        {
            string connectionString =
                     @"mongodb://mymongoaccount98:qO7UgkK52ZLcZmQe499TfOwk8zI0uXaZI9UUp6J7k6vjPORrquc3bftLjArcmRKgXWTKEXjpwfgGACDbpD95ww==@mymongoaccount98.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@mymongoaccount98@";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            return mongoClient;
        }

        public static IMongoCollection<Models.Person> PepoleCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("mohammadcosmosdb");
            var myCollection = database.GetCollection<Models.Person>("Person"); // det ska retunera
            return myCollection;
        }
    }
}
