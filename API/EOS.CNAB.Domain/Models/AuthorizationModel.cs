using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Models
{
    public class AuthorizationModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
       
        public DateTime DataHoraAcesso { get; set; }
        public string? AccessToken { get; set; }
    }
}
