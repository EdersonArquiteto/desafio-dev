using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Validations.Entites;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace EOS.CNAB.Domain.Entities
{
    public class Cnab : IEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public TransactionsTypes Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public DateTime Time { get; set; }
        public string Owner { get; set; }
        public string StoreName { get; set; }
        public ValidationResult Validate => new CnabValidation().Validate(this);

        
    }
}
