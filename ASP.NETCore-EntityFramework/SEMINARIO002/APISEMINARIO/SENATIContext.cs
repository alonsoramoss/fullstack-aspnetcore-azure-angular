using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISEMINARIO;
using Microsoft.EntityFrameworkCore;

namespace APISEMINARIO
{
    public class SENATIContext : DbContext
    {
        public SENATIContext(DbContextOptions<SENATIContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Conocimiento> Conocimientos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TecnicoProyecto> TecnicosProyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la clave primaria compuesta en la tabla TecnicoProyecto
            modelBuilder.Entity<TecnicoProyecto>()
                .HasKey(tp => new { tp.TecnicoId, tp.ProyectoId });
        }
    }
}


