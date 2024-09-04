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
    public class ClienteController : ControllerBase
    {
        public SENATIContext _senatiContext;

        public ClienteController(SENATIContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Cliente> Get()
        {
            return _senatiContext.Clientes.ToList();
        }

        [HttpPost]
        [Route("AgregarCliente")]
        public bool AddCliente([FromBody] ClienteModel clienteModel)
        {
            try
            {
                var cliente = new Cliente
                {
                    NombreCliente = clienteModel.NombreCliente
                };
                _senatiContext.Clientes.Add(cliente);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("updateCliente")]
        public bool UpdateCliente([FromBody] ClienteModel clienteModel)
        {
            try
            {
                var dbCliente = _senatiContext.Clientes.Find(clienteModel.Id);
                if (dbCliente == null)
                    return false;

                dbCliente.NombreCliente = clienteModel.NombreCliente;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteCliente")]
        public bool DeleteCliente([FromBody] ClienteModel clienteModel)
        {
            try
            {
                var dbCliente = _senatiContext.Clientes.Find(clienteModel.Id);

                if (dbCliente == null)
                {
                    return false;
                }

                _senatiContext.Clientes.Remove(dbCliente);
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
