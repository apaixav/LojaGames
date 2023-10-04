using FluentValidation;
using LojaGames.Model;

namespace LojaGames.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(u => u.Usuario)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);

            RuleFor(u => u.Senha)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100);

            RuleFor(u => u.Foto)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(5000);
        }

    }
}
