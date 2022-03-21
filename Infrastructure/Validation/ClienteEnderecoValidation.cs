using FluentValidation;
using LojaXYZ.Entidades;

namespace Infrastructure.Validation
{
    public class ClienteEnderecoValidation : AbstractValidator<ClienteEndereco>
    {
        public ClienteEnderecoValidation()
        {
            RuleFor(m => m.Cep).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Logradouro).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Numero).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Complemento).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Bairro).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Cidade).NotEmpty().WithMessage("Campo obrigatório");

            RuleFor(m => m.Uf).NotEmpty().WithMessage("Campo obrigatório");



        }

    }
}
