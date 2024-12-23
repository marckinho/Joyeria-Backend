﻿using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Customers.Commands.DeleteCustomerCommand
{
    public sealed record DeleteCustomerCommand : IRequest<Response<bool>>
    {
        public int CustomerId { get; set; }
    }
}
