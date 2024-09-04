using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SEMINARIO02.Models
{
    public class TecnicoModel
    {
        public int Id { get; set; }
        public string NombreTecnico { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}