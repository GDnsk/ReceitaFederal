using System;
using System.Collections.Generic;
using System.Text;

namespace ReceitaFederal.Config
{
    public static class MongoConfig
    {
        public readonly static string connectionString = "mongodb://192.168.0.9:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";
        public readonly static string databaseName = "botReceita";

        public readonly static string collectionEmpresas = "empresas";
        public readonly static string collectionSocios = "socios";
    }

}
