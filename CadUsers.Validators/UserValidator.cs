using CadUsers.Entities.DTOs;
using FluentValidation;

namespace CadUsers.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Um email válido é obrigatório.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("O login é obrigatório.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória.");
        }
    }
}
