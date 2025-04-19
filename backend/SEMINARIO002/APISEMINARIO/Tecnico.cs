using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISEMINARIO
{
    public class Tecnico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreTecnico { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        public virtual int? EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; } 
        public List<Conocimiento> Conocimientos { get; set; }
        public List<TecnicoProyecto> TecnicosProyectos { get; set; }
    }

}