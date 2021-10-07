using CSharpRestApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CSharpRestApi.Services
{
    public static class ServerService
    {
        public static List<Server> GetAll(DB context) => context.Servers.Find(_ => true).ToList();

        public static Server Get(DB context, Guid id) => context.Servers.Find(s => s.Id == id).FirstOrDefault();

        public static void Add(DB context, Server server)
        {
            server.Id = Guid.NewGuid();
            context.Servers.InsertOne(server);
        }

        public static void Delete(DB context, Guid id) => context.Servers.DeleteOne(s => s.Id == id);

        public static void Update(DB context, Guid id, Server server)
        {
            server.Id = id;

            context.Servers.FindOneAndUpdate(s => s.Id == id, server.ToBsonDocument());
        }
    }
}