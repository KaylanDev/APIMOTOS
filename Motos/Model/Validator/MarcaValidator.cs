using FluentValidation;

namespace Motos.Model.Validator
{
    public class MarcaValidator : AbstractValidator<Marca>
    {
        public MarcaValidator()
        {
            RuleFor(m => m.NomeMarca).MinimumLength(2).WithMessage("o nome da marca deve ser maior que 2");
           
        }
    }
}
