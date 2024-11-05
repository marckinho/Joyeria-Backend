using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record CreateUserTokenCommand : IRequest<Response<UserDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
