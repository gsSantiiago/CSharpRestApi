using CSharpRestApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CSharpRestApi.Services
{
    public static class ServerService
    {
        static List<Server> Servers { get; }

        static ServerService()
        {
            Servers = new List<Server>
            {
                new Server { Id = Guid.NewGuid(), Name = "Servidor 1" },
                new Server { Id = Guid.NewGuid(), Name = "Servidor 2" }
            };
        }

        public static List<Server> GetAll() => Servers;

        public static Server Get(Guid id) => Servers.FirstOrDefault(s => s.Id.Equals(id));

        public static void Add(Server server)
        {
            server.Id = Guid.NewGuid();
            Servers.Add(server);
        }

        public static void Delete(Guid id)
        {
            var server = Get(id);

            if(server is null)
                return;

            Servers.Remove(server);
        }

        public static void Update(Server server)
        {
            var index = Servers.FindIndex(s => s.Id == server.Id);

            if(index == -1)
                return;

            Servers[index] = server;
        }
    }
}