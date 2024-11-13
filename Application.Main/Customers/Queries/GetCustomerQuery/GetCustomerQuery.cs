using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Customers.Queries.GetCustomerQuery
{
    public sealed record GetCustomerQuery : IRequest<Response<CustomerDto>>
    {
        public int CustomerId { get; set; }

        /*public GetCustomerQuery(string customerId)
        {
            CustomerId = customerId;
        }*/
    }
}
