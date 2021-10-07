
using MongoDB.Driver;
using System;
using System.Configuration;

namespace CSharpRestApi.Models
{
    public class DB
    {
        public IMongoDatabase Database;
        public string DataBaseName = "codigo_premiado";

        public DB()
        {
            IMongoClient client = new MongoClient("mongodb+srv://codigo_premiado:tzWim1kAXwWozRkF@cluster0.zwuif.mongodb.net/codigo_premiado");
            Database = client.GetDatabase(DataBaseName);
        }

        public IMongoCollection<Server> Servers
        {
            get
            {
                IMongoCollection<Server> servers = Database.GetCollection<Server>("servers");

                return servers;
            }
        }
    }
}
