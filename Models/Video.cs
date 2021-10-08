using CSharpRestApi.ViewModels;
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

        [Required]
        [BsonElement("sizeInBytes")]
        [Display(Name = "Tamanho em bytes")]
        public long SizeInBytes { get; set; }

        [Required]
        [BsonElement("createdAt")]
        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
