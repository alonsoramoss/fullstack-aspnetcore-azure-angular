using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISEMINARIOMODEL
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreEmpresa { get; set; }

        // Otras propiedades relacionadas con una empresa, como dirección, número de teléfono, etc.
    }
}