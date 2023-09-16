using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Core
{
    public interface IEntity<Tkey>
    {
        public Tkey Id { get; set; }
        ValidationResult Validate { get; }
    }
}
