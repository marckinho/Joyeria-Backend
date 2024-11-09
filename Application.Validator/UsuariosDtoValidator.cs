using Application.DTO;
using FluentValidation;

namespace Application.Validator
{
    public class UsuariosDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuariosDtoValidator() 
        { 
            RuleFor(u=>u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Pwd).NotNull().NotEmpty();
        }
    }
}