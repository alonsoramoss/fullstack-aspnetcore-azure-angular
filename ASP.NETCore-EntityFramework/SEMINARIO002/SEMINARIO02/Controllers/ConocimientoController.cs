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
    public class ConocimientoController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public ConocimientoController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Conocimiento> Get()
        {
            return _senatiContext.Conocimientos.ToList();
        }

        [HttpPost]
        [Route("AgregarConocimiento")]
        public bool AddConocimiento([FromBody] ConocimientoModel conocimientoModel)
        {
            try
            {
                var conocimiento = new Conocimiento
                {
                    TituloConoc = conocimientoModel.TituloConoc,
                    AreaConoc = conocimientoModel.AreaConoc
                };
                _senatiContext.Conocimientos.Add(conocimiento);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateConocimiento")]
        public bool UpdateConocimiento([FromBody] ConocimientoModel conocimientoModel)
        {
            try
            {
                var dbConocimiento = _senatiContext.Conocimientos.Find(conocimientoModel.Id);
                if (dbConocimiento == null)
                    return false;

                dbConocimiento.TituloConoc = conocimientoModel.TituloConoc;
                dbConocimiento.AreaConoc = conocimientoModel.AreaConoc;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteConocimiento")]
        public bool DeleteConocimiento([FromBody] ConocimientoModel conocimientoModel)
        {
            try
            {
                var dbConocimiento = _senatiContext.Conocimientos.Find(conocimientoModel.Id);

                if (dbConocimiento == null)
                {
                    return false;
                }

                _senatiContext.Conocimientos.Remove(dbConocimiento);
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
