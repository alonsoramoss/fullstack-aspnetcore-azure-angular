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
    public class TecnicoController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public TecnicoController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Tecnico> Get()
        {
            return _senatiContext.Tecnicos.ToList();
        }

        [HttpPost]
        [Route("AgregarTecnico")]
        public bool AddTecnico([FromBody] TecnicoModel tecnicoModel)
        {
            try
            {
                var tecnico = new Tecnico
                {
                    NombreTecnico = tecnicoModel.NombreTecnico,
                    FechaAlta = tecnicoModel.FechaAlta,
                    FechaBaja = tecnicoModel.FechaBaja
                };
                _senatiContext.Tecnicos.Add(tecnico);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateTecnico")]
        public bool UpdateTecnico([FromBody] TecnicoModel tecnicoModel)
        {
            try
            {
                var dbTecnico = _senatiContext.Tecnicos.Find(tecnicoModel.Id);
                if (dbTecnico == null)
                    return false;

                dbTecnico.NombreTecnico = tecnicoModel.NombreTecnico;
                dbTecnico.FechaAlta = tecnicoModel.FechaAlta;
                dbTecnico.FechaBaja = tecnicoModel.FechaBaja;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteTecnico")]
        public bool DeleteTecnico([FromBody] TecnicoModel tecnicoModel)
        {
            try
            {
                var dbTecnico = _senatiContext.Tecnicos.Find(tecnicoModel.Id);

                if (dbTecnico == null)
                {
                    return false;
                }

                _senatiContext.Tecnicos.Remove(dbTecnico);
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
