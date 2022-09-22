using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet.Models
{
    internal class Database
    {
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        public static string connectionString = conf["GissataletDatabase:ConnectionString"].ToString();
        public static string databaseName = conf["GissataletDatabase:DatabaseName"].ToString();
        public static string collectionName = conf["GissataletDatabase:UserCollectionName"].ToString();

        public static async Task setup() 
        {
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
