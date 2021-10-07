using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpRestApi.Models
{
    public class Server
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        [Required]
        [BsonElement("name")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [BsonElement("ip")]
        public string IP { get; set; }

        [Required]
        [BsonElement("port")]
        [Display(Name = "Porta")]
        public int Port { get; set; }
    }
}