using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.Domain.Models;
using EOS.CNAB.Domain.Security;

namespace EOS.CNAB.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private IUsuarioRepository _usuarioRepository;
        private IAuthorizationSecurity _authorizationSecurity;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IAuthorizationSecurity authorizationSecurity)
        {
            _usuarioRepository = usuarioRepository;
            _authorizationSecurity = authorizationSecurity;
        }

        public AuthorizationModel AutenticarUsuario(string email, string senha)
        {
            var usuario = _usuarioRepository.GetByEmailAndSenha(email, senha);

            DomainException.When(
                usuario == null,
                "Acesso negado. Usuário não encontrado."
                );

            return new AuthorizationModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
                AccessToken = _authorizationSecurity.CreateToken(usuario)
            };
        }

        public void CriarUsuario(Usuario usuario)
        {
            //Não é permitido cadastrar usuários com o mesmo email.
            DomainException.When(
                    //_usuarioRepository.GetByEmail(usuario.Email) != null, $"O email {usuario.Email} já está cadastrado."
                    _usuarioRepository.GetByEmail(usuario.Email) != null, $"O email {usuario.Email} já está cadastrado."
                );
            _usuarioRepository.Create(usuario);
        }

       
    }
}
