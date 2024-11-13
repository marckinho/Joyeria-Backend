using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.ProductosDto;
using Domain.Entities;

namespace Aplication.Interface.Persistence
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<ListaProductosDto>> GetAsync(int customerId=0);
    }
}
