using Microsoft.EntityFrameworkCore;
using WebApiFutbolistas.Entidades;

namespace WebApiFutbolistas
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Futbolista> Futbolistas {get; set;}

        public DbSet<Equipo> Equipos {get; set;}
    }
}
