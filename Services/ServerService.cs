using CSharpRestApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using CSharpRestApi.Classes;
using System.Net.Sockets;

namespace CSharpRestApi.Services
{
    public static class ServerService
    {
        public static List<Server> GetAll(DB context)
        {
            try
            {
                return context.Servers.Find(_ => true).ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static Server Get(DB context, Guid id)
        {
            try
            {
                return context.Servers.Find(s => s.Id == id).FirstOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static bool GetAvailable(DB context, Guid id) {
            try
            {
                Server server = context.Servers.Find(s => s.Id == id).FirstOrDefault();

                using TcpClient client = new(server.IP, server.Port);

                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
         }

        public static void Add(DB context, Server server)
        {
            try
            {
                server.Id = Guid.NewGuid();
                context.Servers.InsertOne(server);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static void Delete(DB context, Guid id)
        {
            try
            {
                context.Servers.DeleteOne(s => s.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Update(DB context, Guid id, Server server)
        {
            try
            {
                server.Id = id;

                context.Servers.FindOneAndUpdate(s => s.Id == id, server.ToBsonDocument());
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}