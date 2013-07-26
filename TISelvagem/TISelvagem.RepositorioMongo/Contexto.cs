using System;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;

namespace TISelvagem.RepositorioMongo
{
    public class Contexto<T> where T : class
    {
        private readonly MongoDatabase db;
        private readonly MongoServer server;

        public Contexto()
        {
            var connectionString = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["TISelvagemMongo"].ConnectionString);

            var mongoSettings = new MongoClientSettings
            {
                Server = connectionString.Server,
                //DefaultCredentials = new MongoCredentials(connectionString.Username, connectionString.Password)
            };
            var mongoClient = new MongoClient(mongoSettings);

            server = mongoClient.GetServer();
            db = server.GetDatabase(connectionString.DatabaseName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());

            //corrige a hora no servidor do banco
            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);

            var w7Convensoes = new ConventionProfile();

            //Ajuda no migration, se tiver campo a mais no banco ele ignora
            w7Convensoes.SetIgnoreExtraElementsConvention(new AlwaysIgnoreExtraElementsConvention());
            BsonClassMap.RegisterConventions(w7Convensoes, (type) => true);
        }
       
        

        public MongoCollection<T> Collection { get; private set; }
    }
}
