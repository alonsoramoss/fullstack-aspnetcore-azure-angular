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
    public class ProyectoController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public ProyectoController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Proyecto> Get()
        {
            return _senatiContext.Proyectos.ToList();
        }

        [HttpPost]
        [Route("AgregarProyecto")]
        public bool AddProyecto([FromBody] ProyectoModel proyectoModel)
        {
            try
            {
                var proyecto = new Proyecto
                {
                    NombreProyecto = proyectoModel.NombreProyecto,
                    FechaInicio = proyectoModel.FechaInicio,
                    FechaFin = proyectoModel.FechaFin
                };
                _senatiContext.Proyectos.Add(proyecto);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateProyecto")]
        public bool UpdateProyecto([FromBody] ProyectoModel proyectoModel)
        {
            try
            {
                var dbProyecto = _senatiContext.Proyectos.Find(proyectoModel.Id);
                if (dbProyecto == null)
                    return false;

                dbProyecto.NombreProyecto = proyectoModel.NombreProyecto;
                dbProyecto.FechaInicio = proyectoModel.FechaInicio;
                dbProyecto.FechaFin = proyectoModel.FechaFin;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteProyecto")]
        public bool DeleteProyecto([FromBody] ProyectoModel proyectoModel)
        {
            try
            {
                var dbProyecto = _senatiContext.Proyectos.Find(proyectoModel.Id);

                if (dbProyecto == null)
                {
                    return false;
                }

                _senatiContext.Proyectos.Remove(dbProyecto);
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
