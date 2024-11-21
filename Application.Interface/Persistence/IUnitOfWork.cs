﻿using Application.Interface.Persistence;
using System;

namespace Aplication.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsuariosRepository Usuarios { get; }
        IProductoRepository Productos { get; }
        ITipoProductoVentaRepository Tipo_Producto_Venta { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
