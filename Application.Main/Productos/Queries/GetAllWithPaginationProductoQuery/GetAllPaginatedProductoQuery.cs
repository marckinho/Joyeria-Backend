﻿using Application.DTO;
using Application.DTO.ProductosDto;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllWithPaginationProductoQuery
{
    public sealed record GetAllPaginatedProductoQuery :IRequest<ResponsePagination<IEnumerable<ProductoTipoVentaDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ProductName { get; set; }
    }
}
