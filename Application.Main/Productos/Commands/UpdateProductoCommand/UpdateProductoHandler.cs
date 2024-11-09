using Aplication.Interface.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Commands.UpdateProductoCommand
{
    public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var producto = _mapper.Map<Producto>(request);
            response.Data = await _unitOfWork.Productos.UpdateAsync(producto);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Actualizado!";
            }

            return response;
        }
    }
}
