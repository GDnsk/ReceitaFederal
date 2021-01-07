using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using ReceitaFederal.Config;
using ReceitaFederal.Models;
using System.Linq;

namespace ReceitaFederal.Services
{
    class MongoService
    {
        public MongoClient clientConnection;
        public IMongoCollection<Empresa> empresasCollection;
        public IMongoCollection<Socio> sociosCollection;

        public MongoService()
        {
            clientConnection = new MongoClient(MongoConfig.connectionString);
            var database = clientConnection.GetDatabase(MongoConfig.databaseName);

            empresasCollection = database.GetCollection<Empresa>(MongoConfig.collectionEmpresas);
            sociosCollection = database.GetCollection<Socio>(MongoConfig.collectionSocios);
        }
    }
}
