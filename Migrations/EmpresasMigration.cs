using System;
using ReceitaFederal.Services;
using System.IO;
using System.Collections.Generic;
using ReceitaFederal.Models;
using System.Linq;
using ReceitaFederal;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ReceitaFederal.Migrations
{
    class EmpresasMigration
    {

        public static void Migrate(string[] args)
        {
            if (args.Contains("--migrate") == false) return;

            Console.WriteLine("Starting migration process, this may take a while...");

            // 1. Download Zip File
            string path = HttpService.DownloadFile(new Uri("http://200.152.38.155/CNPJ/DADOS_ABERTOS_CNPJ_01.zip"));

            string outputBase = @$"{FileService.GetProjectRootPath()}download\csv";

            // 2. Extract Zip information to csv
            CPNJBaseParser.ParseBaseToCSV(path, outputBase);


            // 3. Retrieve csv data
            Console.WriteLine("Retrieving data...");
            List<Empresa> empresas = CSV.ParseEmpresas($"{outputBase}\\empresas.csv");
            List<Socio> socios = CSV.ParseSocios($"{outputBase}\\socios.csv");


            // 4. Connect to DataBase
            MongoService mongo = new MongoService();

            // 5. Insert data to database
            Console.WriteLine("Inserting data to DataBase...");

            mongo.empresasCollection.InsertMany(empresas);
            mongo.sociosCollection.InsertMany(socios);
        }

    }
}
