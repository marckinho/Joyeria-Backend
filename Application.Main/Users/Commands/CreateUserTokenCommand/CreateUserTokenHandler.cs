using Aplication.Interface.Persistence;
using Application.DTO;
using AutoMapper;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Users.Commands.CreateUserTokenCommand
{
    public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UsuarioDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UsuarioDto>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<UsuarioDto>();
            var user = await _unitOfWork.Usuarios.Authenticate(request.UserName, request.Pwd);

            if(user is null)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                return response;
            }

            response.Data = _mapper.Map<UsuarioDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticacion exitosa!";

            return response;
        }
    }
}
