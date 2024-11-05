using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Customers.Queries.GetAllCustomerQuery
{
    public sealed record GetAllCustomerQuery :IRequest<Response<IEnumerable<CustomerDto>>>
    {
    }
}
