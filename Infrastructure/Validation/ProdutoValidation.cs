﻿using FluentValidation;
using LojaXYZ.Entidades;

namespace Infrastructure.Validation
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(m => m.Nome).Null();

            RuleFor(m => m.Descricao).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Foto).Null();

            RuleFor(m => m.Preco).NotEmpty();

        }

    }
}