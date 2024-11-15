using Aplication.Interface.Persistence;
using Application.DTO;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Customers.Queries.GetAllWithPaginationCustomerQuery
{
    public class GetAllWithPaginationCustomerHandler : IRequestHandler<GetAllWithPaginationCustomerQuery, ResponsePagination<IEnumerable<CustomerDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> Handle(GetAllWithPaginationCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();

            var count = await _unitOfWork.Customers.CountAsync();

            var customers = await _unitOfWork.Customers.GetAllWithPaginationAsync(request.PageNumber, request.PageSize,request.CustomerName);
            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

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