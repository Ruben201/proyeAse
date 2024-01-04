using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Aseguradora.Data.Seed;
using Aseguradora.Models;

namespace Aseguradora.Data
{
    public class IdentityContext : IdentityDbContext<CustomIdentityUser>
    {
        //El constructor de la clase
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        //Este DbSet nos permitirá acceder a los usuarios en los controladores
        public DbSet<CustomIdentityUser> CustomIdentities { get; set; }
        //Esta funcion se llama al aplicar una migracion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Vamos a agregar 1 usuario al momento de crear la base de datos
            modelBuilder.SeedUserIdentityData();
        }
    }
}
