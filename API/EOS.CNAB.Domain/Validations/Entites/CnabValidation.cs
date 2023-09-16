
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Validations.Docs;
using FluentValidation;

namespace EOS.CNAB.Domain.Validations.Entites
{
    public class CnabValidation : AbstractValidator<Cnab>
    {
        public CnabValidation()
        {

           
            RuleFor(c => c.Type)
                .NotEmpty()
                .WithMessage("O tipo é obrigatório");
            RuleFor(c => c.Date)
                .NotEmpty()
                .WithMessage("A Data é obrigatória");
            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage("O valor é obrigatório");
            RuleFor(c => c.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(c => CpfValidacao.Validar(c.CPF)).Equal(true)
                .WithMessage("O CPF Fornecido é inválido");
            RuleFor(C => C.Card)
                .NotEmpty()
                .WithMessage("O cartão é obrigatório");
            RuleFor(c => c.Owner)
                .NotEmpty()
                .WithMessage("O dono é obrigatório");
            RuleFor(c => c.StoreName)
                .NotEmpty()
                .WithMessage("A loja é obrigatória");

        }
    }
}
