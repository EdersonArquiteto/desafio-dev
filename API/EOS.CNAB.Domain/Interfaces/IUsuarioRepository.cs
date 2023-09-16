using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Usuario GetByEmail(string email);
        Usuario GetByEmailAndSenha(string email, string senha);
    }
}
