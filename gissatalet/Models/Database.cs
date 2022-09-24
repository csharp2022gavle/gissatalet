using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace gissatalet.Models
{
    internal class Database
    {
        public static async Task setup() 
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string connectionString = config["Database:ConnectionString"];
            string databaseName = config["Database:DatabaseName"];
            string collectionName = config["Database:DatabaseCollection"];
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<user.User>(collectionName);
            var results = await collection.FindAsync(_ => true);
            foreach (var result in results.ToList()) 
            {
                models.Tasks.Users.Add(result);
            }
        }


    }
}
