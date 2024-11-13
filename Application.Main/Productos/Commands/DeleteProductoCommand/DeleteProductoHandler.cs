using Aplication.Interface.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Commands.DeleteProductoCommand
{
    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            response.Data = await _unitOfWork.Productos.DeleteAsync(request.productoId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Borrado!";
            }

            return response;
        }
    }
}
