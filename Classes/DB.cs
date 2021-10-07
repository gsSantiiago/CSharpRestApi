
using CSharpRestApi.Models;
using MongoDB.Driver;
using System;
using System.IO;

namespace CSharpRestApi.Classes
{
    public class DB
    {
        public IMongoDatabase Database;

        public DB()
        {
            string root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);

            IMongoClient client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
            Database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE"));
        }

        public IMongoCollection<Server> Servers
        {
            get
            {
                return Database.GetCollection<Server>("servers");
            }
        }
    }
}
