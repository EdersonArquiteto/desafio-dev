using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Validations.Entites;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Entities
{
    public class Usuario : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataHoraCriacao { get; set; }

       

        public ValidationResult Validate => new UsuarioValidation().Validate(this);
    }
}
