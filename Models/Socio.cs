using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using ReceitaFederal.Utils;

namespace ReceitaFederal.Models
{
    class Socio
    {
        public ObjectId id;
        public string cnpjEmpresa { get; set; }
        public string identificadorSocio { get; set; }
        public string nomeSocio { get; set; }
        public string razaoSocial { get; set; }
        public string cnpjOrCpf { get; set; }
        public bool pj { get; set; }


        public Socio(string csvLine)
        {
            string[] values = csvLine.Split("\",\"");
            cnpjEmpresa = StringUtils.RemoveDoubleQuotes(values[0]);
            identificadorSocio = StringUtils.RemoveDoubleQuotes(values[1]);

            if (identificadorSocio == "2")
            {
                // Is PF
                pj = false;
                nomeSocio = StringUtils.RemoveDoubleQuotes(values[2]);
            }
            else if (identificadorSocio == "3")
            {
                // Is PJ
                pj = true;
                razaoSocial = StringUtils.RemoveDoubleQuotes(values[2]);
            }
            else
            {
                // Is Foreign
                pj = false;
                nomeSocio = StringUtils.RemoveDoubleQuotes(values[2]);
            }
            cnpjOrCpf = StringUtils.RemoveDoubleQuotes(values[3]);
        }
    }
}
