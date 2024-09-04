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
    public class CategoriaController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public CategoriaController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Categoria> Get()
        {
            return _senatiContext.Categorias.ToList();
        }

        [HttpPost]
        [Route("AgregarCategoria")]
        public bool AddCategoria([FromBody] CategoriaModel categoriaModel)
        {
            try
            {
                var categoria = new Categoria
                {
                    NombreCategoria = categoriaModel.NombreCategoria
                };
                _senatiContext.Categorias.Add(categoria);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateCategoria")]
        public bool UpdateCategoria([FromBody] CategoriaModel categoriaModel)
        {
            try
            {
                var dbCategoria = _senatiContext.Categorias.Find(categoriaModel.Id);
                if (dbCategoria == null)
                    return false;

                dbCategoria.NombreCategoria = categoriaModel.NombreCategoria;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteCategoria")]
        public bool DeleteCategoria([FromBody] CategoriaModel categoriaModel)
        {
            try
            {
                var dbCategoria = _senatiContext.Categorias.Find(categoriaModel.Id);

                if (dbCategoria == null)
                {
                    return false;
                }

                _senatiContext.Categorias.Remove(dbCategoria);
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
