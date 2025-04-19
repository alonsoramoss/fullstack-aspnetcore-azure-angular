using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMINARIO02.Models
{
    public class TecnicoProyectoModel
    {
        public int TecnicoId { get; set; }
        public int ProyectoId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaCese { get; set; }
    }
}