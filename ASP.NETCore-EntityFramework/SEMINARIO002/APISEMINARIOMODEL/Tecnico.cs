using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISEMINARIOMODEL
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreTecnico { get; set; }

        // Otras propiedades relacionadas con un técnico, como fecha de inicio, fecha de fin, etc.
    }
}