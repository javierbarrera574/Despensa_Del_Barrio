using Microsoft.EntityFrameworkCore;
using Prueba.BD.Datos.Entidades;

namespace Prueba.BD.Datos
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Deposito> Depositos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

    }
}
