using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TISelvagem.RepositorioMongo
{
    public class AlunoDTO
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Mae { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
