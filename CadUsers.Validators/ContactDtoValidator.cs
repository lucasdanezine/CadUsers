using CadUsers.Entities.DTOs;
using FluentValidation;

namespace CadUsers.Validators
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("O ID do usuário é obrigatório.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("O telefone é obrigatório.");
        }
    }
}
