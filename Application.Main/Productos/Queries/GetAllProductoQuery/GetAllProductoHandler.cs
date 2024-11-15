using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllProductoQuery
{

    public class GetAllProductoHandler : IRequestHandler<GetAllProductoQuery, Response<IEnumerable<ProductoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProductoDto>>> Handle(GetAllProductoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<ProductoDto>>();

            var productos = await _unitOfWork.Productos.GetAsync();
            response.Data = _mapper.Map<List<ProductoDto>>(productos);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }

            return response;
        }
    }
}
