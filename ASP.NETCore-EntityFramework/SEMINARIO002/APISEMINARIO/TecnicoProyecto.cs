using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISEMINARIO
{
    public class TecnicoProyecto
    {
        [Key]
        [Column(Order = 0)]
        public virtual int? TecnicoId { get; set; }
        public virtual Tecnico Tecnico { get; set; }
        [Key]
        [Column(Order = 1)]
        public virtual int? ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaCese { get; set; }
    }
}
