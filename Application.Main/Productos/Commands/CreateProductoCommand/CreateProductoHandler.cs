﻿using Aplication.Interface.Persistence;
using ApplicationUseCases.Customers.Commands.CreateCustomerCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Commands.CreateProductoCommand
{
    public class CreateProductoHandler : IRequestHandler<CreateProductoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var producto = _mapper.Map<Producto>(request);
            response.Data = await _unitOfWork.Productos.InsertAsync(producto);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!";
            }

            return response;
        }
    }
}
