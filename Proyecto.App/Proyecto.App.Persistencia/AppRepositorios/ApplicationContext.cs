using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;

namespace Proyecto.App.Persistencia
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Abogado> Abogados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<FaseCaso> FaseCasos { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {       
                //LOCAL
                //optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=PROYECTO_CICLO_3");
                //REMOTO
                optionsBuilder.UseSqlServer("workstation id=JSGOMEZABOGADOS.mssql.somee.com;packet size=4096;user id=gomez2799_SQLLogin_1;pwd=oo3yf8mg9f;data source=JSGOMEZABOGADOS.mssql.somee.com;persist security info=False;initial catalog=JSGOMEZABOGADOS");
            }
        }

    }
}
