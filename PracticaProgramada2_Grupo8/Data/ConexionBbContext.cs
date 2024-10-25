using Microsoft.EntityFrameworkCore;

namespace PracticaProgramada2_Grupo8.Data
{
    //Heredar de la base entityFramework
    //Creamos el contexto de la base de datos
    public class ConexionBbContext : DbContext
    {

        public ConexionBbContext(DbContextOptions <ConexionBbContext> options) : base (options) { }


        //"ConnectionString": {
        //"ConexionBD": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
        //},


    }
}
