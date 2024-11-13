﻿using Application.DTO.ProductosDto;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllWithPaginationProductoQuery
{
    public sealed record GetAllPaginatedProductoQuery :IRequest<ResponsePagination<IEnumerable<ProductoDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}