using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetProductoQuery
{
    public class GetProductoHandler : IRequestHandler<GetProductoQuery, Response<IEnumerable<ListaProductosDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ListaProductosDto>>> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<ListaProductosDto>>();

            var product = await _unitOfWork.Productos.GetAsync(request.Id);
            response.Data = _mapper.Map<List<ListaProductosDto>>(product);

            if (product.Count()==0)
            {
                response.IsSuccess = true;
                response.Message = "Producto no existe";
                return response;
            }

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }

            return response;
        }
    }
}
