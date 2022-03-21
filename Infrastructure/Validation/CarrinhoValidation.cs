using FluentValidation;
using LojaXYZ.Entidades;

namespace Infrastructure.Validation
{
    public class CarrinhoValidation : AbstractValidator<Carrinho>
    {
        public CarrinhoValidation()
        {
            RuleFor(m => m.ValorTotal).NotEmpty().WithMessage("Campo obrigatório");
        }

    }
}
