using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record CreateUserTokenCommand : IRequest<Response<UsuarioDto>>
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }

    }
}
