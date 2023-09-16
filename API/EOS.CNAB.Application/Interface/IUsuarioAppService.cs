using EOS.CNAB.Application.DTO;
using EOS.CNAB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task CriarUsuario(CriarUsuarioInput criarUsuario);

        Task<AuthorizationModel> AutenticarUsuario(AutenticarUsuarioInput autenticarUsuario);
           

    }
}
