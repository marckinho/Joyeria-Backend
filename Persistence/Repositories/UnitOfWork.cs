﻿using Aplication.Interface.Persistence;
using Application.Interface.Persistence;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }
        public IUsuariosRepository Usuarios { get; }
        public IProductoRepository Productos { get; }

        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ICustomersRepository customers,IUsuariosRepository usuarios,IProductoRepository productos, ApplicationDbContext applicationDbContext) 
        {
            Customers = customers;
            Usuarios = usuarios;
            Productos = productos;
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
