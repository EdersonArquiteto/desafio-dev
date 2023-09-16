using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Services
{
    public interface IUsuarioDomainService 
    {
        void CriarUsuario(Usuario usuario);
        AuthorizationModel AutenticarUsuario(string email, string senha);
    }
}
