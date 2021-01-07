using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ReceitaFederal.Utils;
using System.Text.Json;


namespace ReceitaFederal.Models
{
    class Empresa
    {
        public ObjectId id;
        public string cnpj { get; set; }
        public string identificadorMatrix { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string capitalSocial { get; set; }
        public string situacaoCadastral { get; set; }
        public string dataSituacao { get; set; }
        public string cep { get; set; }

        private List<Socio> _socios = new List<Socio>();
        public IList<Socio> socios { get { return _socios; } set { _socios = (List<Socio>)value; } }


        public Empresa(string csvLine)
        {
            string[] values = csvLine.Split("\",\"");
            cnpj = StringUtils.RemoveDoubleQuotes(values[0]);
            identificadorMatrix = StringUtils.RemoveDoubleQuotes(values[1]);
            razaoSocial = StringUtils.RemoveDoubleQuotes(values[2]);
            nomeFantasia = StringUtils.RemoveDoubleQuotes(values[3]);
            situacaoCadastral = StringUtils.RemoveDoubleQuotes(values[4]);
            dataSituacao = StringUtils.RemoveDoubleQuotes(values[5]);
            cep = StringUtils.RemoveDoubleQuotes(values[18]);
            capitalSocial = StringUtils.RemoveDoubleQuotes(values[31]);
        }
    }
}
