using Aplication.Interface.Persistence;
using Application.DTO;
using Application.DTO.ProductosDto;
using ApplicationUseCases.Productos.Queries.GetAllProductoQuery;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.TipoProductoVenta.Queries.GetAllTipoProductoVentaQuery
{
    public class GetAllTipoProductoVentaHandler : IRequestHandler<GetAllTipoProductoVentaQuery, Response<IEnumerable<Tipo_Producto_VentaDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTipoProductoVentaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<Tipo_Producto_VentaDto>>> Handle(GetAllTipoProductoVentaQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<Tipo_Producto_VentaDto>>();

            var data = await _unitOfWork.Productos.GetAsync();
            response.Data = _mapper.Map<List<Tipo_Producto_VentaDto>>(data);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }

            return response;
        }
    }
}
