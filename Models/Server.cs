using System;

namespace CSharpRestApi.Models
{
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
    }
}