using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Interceptors;
using System.Reflection;
using System.Reflection.Emit;

namespace Persistence.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options) 
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tipo_Producto_Venta> Tipo_Producto_Venta { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<TipoInventario> TipoInventario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            /*builder.Entity<Producto>()
            .Property(c => c.Activo)
            .HasConversion(
                v => v ? (byte)1 : (byte)0, // Conversión de `bool` a `byte` al guardar
                v => v == 1 // Conversión de `byte` a `bool` al leer
            );*/

            /*builder.Entity<Producto>()
            .Property(p => p.Activo)
            .HasColumnType("bit");*/

            builder.Entity<Producto>()
            .HasOne(p => p.Tipo_Producto_Venta)  // Relación de Producto a TipoProductoVenta
            .WithMany(t => t.Productos)        // Relación inversa: TipoProductoVenta tiene muchos Productos
            .HasForeignKey(p => p.Tipo_Producto_Venta_Id)  // Clave foránea
            .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
