using FluentValidation;
using LojaXYZ.Entidades;

namespace Infrastructure.Validation
{
    public class ItemCarrinhoValidation : AbstractValidator<ItemCarrinho>
    {
        public ItemCarrinhoValidation()
        {
            RuleFor(m => m.Quantidade).NotEmpty().WithMessage("Campo obrigatório");
        }

    }

}

