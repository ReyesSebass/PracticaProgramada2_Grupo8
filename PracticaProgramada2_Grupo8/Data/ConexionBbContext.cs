using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_Grupo8.Models;

namespace PracticaProgramada2_Grupo8.Data
{
    //Heredar de la base entityFramework
    //Creamos el contexto de la base de datos

    //"ConnectionString": {
    //"ConexionBD": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
    //},

    public class ConexionBbContext : DbContext
    {
        public ConexionBbContext(DbContextOptions <ConexionBbContext> options) : base (options) { }

        // Parte de Usuarios
        public DbSet<UsuarioModel> G8_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().ToTable("G8_USUARIOS");
        }
    }
}
