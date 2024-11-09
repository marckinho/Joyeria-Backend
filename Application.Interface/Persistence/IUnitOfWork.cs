﻿using Application.Interface.Persistence;
using System;

namespace Aplication.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsuariosRepository Usuarios { get; }
        IDiscountRepository Discounts { get; }
        IProductoRepository Productos { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
