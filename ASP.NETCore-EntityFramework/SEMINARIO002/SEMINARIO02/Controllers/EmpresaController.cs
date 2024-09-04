using APISEMINARIO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEMINARIO02.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEMINARIO02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private SENATIContext _senatiContext;

        public EmpresaController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Empresa> Get()
        {
            return _senatiContext.Empresas.ToList();
        }

        [HttpPost]
        [Route("AgregarEmpresa")]
        public bool AddEmpresa([FromBody] EmpresaModel empresaModel)
        {
            try
            {
                var empresa = new Empresa { NombreEmpresa = empresaModel.NombreEmpresa };
                _senatiContext.Empresas.Add(empresa);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateEmpresa")]
        public bool UpdateEmpresa([FromBody] EmpresaModel empresaModel)
        {
            try
            {
                var dbEmpresa = _senatiContext.Empresas.Find(empresaModel.Id);
                if (dbEmpresa == null)
                    return false;

                dbEmpresa.NombreEmpresa = empresaModel.NombreEmpresa;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteEmpresa")]
        public bool DeleteEmpresa([FromBody] EmpresaModel empresaModel)
        {
            try
            {
                var dbEmpresa = _senatiContext.Empresas.Find(empresaModel.Id);

                if (dbEmpresa == null)
                {
                    return false;
                }

                _senatiContext.Empresas.Remove(dbEmpresa);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}