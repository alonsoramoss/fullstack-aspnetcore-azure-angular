using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMINARIO02.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public required string NombreCliente { get; set; }
    }
}