using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.Interface.Persistence
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        
    }
}
