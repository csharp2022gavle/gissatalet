using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace gissatalet.models
{
    internal class Database
    {
        public static async Task Setup() 
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
                Tasks.Users.Add(result);
            }
        }


    }
}
