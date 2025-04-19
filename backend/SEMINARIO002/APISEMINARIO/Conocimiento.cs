using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APISEMINARIO
{
    public class Conocimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TituloConoc { get; set; }
        public string AreaConoc { get; set; }
        
        public virtual int? TecnicoId { get; set; }
        public virtual Tecnico Tecnicos { get; set; } 
    }
}
