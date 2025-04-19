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
    public class TecnicoProyectoController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public TecnicoProyectoController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<TecnicoProyecto> Get()
        {
            return _senatiContext.TecnicosProyectos.ToList();
        }

        [HttpPost]
        [Route("AgregarTecnicoProyecto")]
        public bool AddTecnicoProyecto([FromBody] TecnicoProyectoModel tecnicoProyectoModel)
        {
            try
            {
                var tecnicoProyecto = new TecnicoProyecto
                {
                    TecnicoId = tecnicoProyectoModel.TecnicoId,
                    ProyectoId = tecnicoProyectoModel.ProyectoId,
                    FechaAsignacion = tecnicoProyectoModel.FechaAsignacion,
                    FechaCese = tecnicoProyectoModel.FechaCese
                };
                _senatiContext.TecnicosProyectos.Add(tecnicoProyecto);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateTecnicoProyecto")]
        public bool UpdateTecnicoProyecto([FromBody] TecnicoProyectoModel tecnicoProyectoModel)
        {
            try
            {
                var dbTecnicoProyecto = _senatiContext.TecnicosProyectos
                    .FirstOrDefault(tp => tp.TecnicoId == tecnicoProyectoModel.TecnicoId && tp.ProyectoId == tecnicoProyectoModel.ProyectoId);
                if (dbTecnicoProyecto == null)
                    return false;

                dbTecnicoProyecto.FechaAsignacion = tecnicoProyectoModel.FechaAsignacion;
                dbTecnicoProyecto.FechaCese = tecnicoProyectoModel.FechaCese;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteTecnicoProyecto")]
        public bool DeleteTecnicoProyecto([FromBody] TecnicoProyectoModel tecnicoProyectoModel)
        {
            try
            {
                var dbTecnicoProyecto = _senatiContext.TecnicosProyectos
                    .FirstOrDefault(tp => tp.TecnicoId == tecnicoProyectoModel.TecnicoId && tp.ProyectoId == tecnicoProyectoModel.ProyectoId);

                if (dbTecnicoProyecto == null)
                {
                    return false;
                }

                _senatiContext.TecnicosProyectos.Remove(dbTecnicoProyecto);
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

