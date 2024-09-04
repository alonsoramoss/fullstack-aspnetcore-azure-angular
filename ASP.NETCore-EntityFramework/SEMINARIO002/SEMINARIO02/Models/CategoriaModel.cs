using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMINARIO02.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
    }
}