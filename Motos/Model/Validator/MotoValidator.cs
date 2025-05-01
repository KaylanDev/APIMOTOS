using FluentValidation;
using Motos.API.Model;

namespace Motos.API.Model.Validator
{
    public class MotoValidator : AbstractValidator<MotosM>
    {
        public MotoValidator()
        {
            RuleFor(m => m.Modelo)
                .NotEmpty().WithMessage("O modelo é obrigatório")
                .MinimumLength(3).WithMessage("O modelo deve ter no mínimo 3 caracteres")
                .MaximumLength(50).WithMessage("O modelo deve ter no máximo 50 caracteres");

            RuleFor(m => m.Potencia)
                .GreaterThan(0).WithMessage("A potência deve ser maior que 0")
                .LessThan(4000).WithMessage("A potência deve ser menor que 4000");

            RuleFor(m => m.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que 0")
                .LessThan(1000000).WithMessage("O preço deve ser menor que 1.000.000");

            RuleFor(m => m.Imagem).MinimumLength(5).WithMessage("a url da imagem deve ser maior q 5 caracteres");

        }
    }
}
