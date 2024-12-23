﻿using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllWithPaginationProductoQuery
{
    public class GetAllPaginatedProductoHandler : IRequestHandler<GetAllPaginatedProductoQuery, ResponsePagination<IEnumerable<ListaProductosDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPaginatedProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<ListaProductosDto>>> Handle(GetAllPaginatedProductoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<ListaProductosDto>>();

            var count = await _unitOfWork.Productos.CountAsync();

            var productos = await _unitOfWork.Productos.GetAllWithPaginationAsync(request.PageNumber, request.PageSize, request.ProductName);
            response.Data = _mapper.Map<IEnumerable<ListaProductosDto>>(productos);

            if (response.Data != null)
            {
                response.PageNumber = request.PageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta Paginada Exitosa!!!";
            }

            return response;
        }
    }
}