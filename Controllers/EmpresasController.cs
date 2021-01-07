using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReceitaFederal.Services;
using ReceitaFederal.Models;
using MongoDB.Driver;
using System.Text.Json;

namespace ReceitaFederal.Controllers
{
    [ApiController]
    [Route("cnpj/{cnpj?}")]
    public class EmpresasController : Controller
    {
        
        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get(string? cnpj)
        {
            MongoService mongo = new MongoService();
            var empresasFilter = Builders<Empresa>.Filter.Eq(e => e.cnpj, cnpj);
            var sociosFilter = Builders<Socio>.Filter.Eq(e => e.cnpjEmpresa, cnpj);

            Empresa empresa = mongo.empresasCollection.FindSync<Empresa>(empresasFilter).ToList().First();
            List<Socio> socios = mongo.sociosCollection.FindSync<Socio>(sociosFilter).ToList();


            if (empresa == null)
            {
                return Json("Not Found");
            }

            empresa.socios = socios;
            return Json(empresa);
        }
    }
}
