using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllProductoQuery
{

    public class GetAllProductoHandler : IRequestHandler<GetAllProductoQuery, Response<IEnumerable<ListaProductosDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ListaProductosDto>>> Handle(GetAllProductoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<ListaProductosDto>>();

            var productos = await _unitOfWork.Productos.GetAllAsync();
            response.Data = _mapper.Map<List<ListaProductosDto>>(productos);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }

            return response;
        }
    }
}
