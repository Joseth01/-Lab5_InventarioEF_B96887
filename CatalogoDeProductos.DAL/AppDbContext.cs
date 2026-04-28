namespace CatalogoDeProductos.DAL
{
    using Microsoft.EntityFrameworkCore;
    using CatalogoDeProductos.Model;

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opciones)
          : base(opciones)
        {
     
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
