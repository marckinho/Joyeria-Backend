using Aplication.Interface.Persistence;
using Application.Interface.Persistence;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsuariosRepository Usuarios { get; }
        public IProductoRepository Productos { get; }
        public ITipoProductoVentaRepository Tipo_Producto_Venta { get; }


        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(IUsuariosRepository usuarios,IProductoRepository productos, ApplicationDbContext applicationDbContext,ITipoProductoVentaRepository tipoProductoVenta) 
        {
            Usuarios = usuarios;
            Productos = productos;
            Tipo_Producto_Venta = tipoProductoVenta;
            _applicationDbContext = applicationDbContext;
        }

        public void Dispose() 
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
