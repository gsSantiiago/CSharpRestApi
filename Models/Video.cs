using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpRestApi.Models
{
    public class Video
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        [Required]
        [BsonElement("description")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
