using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReceitaFederal.Models;

namespace ReceitaFederal.Services
{
    class CSV
    {
        public static List<Empresa> ParseEmpresas(string path)
        {
            return File.ReadAllLines(path).Skip(1).Select(v => new Empresa(v)).ToList();
        }

        public static List<Socio> ParseSocios(string path)
        {
            return File.ReadAllLines(path).Skip(1).Select(v => new Socio(v)).ToList();
        }
    }
}
