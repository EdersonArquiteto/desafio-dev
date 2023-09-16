using Bogus;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using FluentAssertions;
using Xunit;

namespace EOS.CNAB.UnitTest.Repositories
{
    public class UserRepositoryTest
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserRepositoryTest(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [Fact]
        public void TestCreate()
        {
            #region Realizando o cadastro de um usuário

            var usuario = CreateUsuario();

            #endregion

            #region Verificando se o usuário foi cadastrado

            var usuarioByEmail= _usuarioRepository.GetByEmail(usuario.Email);

            usuarioByEmail.Should().NotBeNull();
            usuarioByEmail.Nome.Should().Be(usuario.Nome);
            usuarioByEmail.Email.Should().Be(usuario.Email);

            #endregion
        }
        [Fact]
        public void TestGetByEmail()
        {
            #region Realizando o cadastro de um usuário

            var usuario = CreateUsuario();

            #endregion

            #region Consultando o usuário através do email

            var usuarioByEmail = _usuarioRepository.GetByEmail(usuario.Email);

            #endregion

            #region Verificando se o usuário foi retornado na consulta

            usuarioByEmail.Should().NotBeNull();
            usuarioByEmail.Nome.Should().Be(usuario.Nome);
            usuarioByEmail.Email.Should().Be(usuario.Email);

            #endregion
        }

        [Fact]
        public void GetByEmailAndSenha()
        {
            #region Realizando o cadastro de um usuário

            var usuario = CreateUsuario();

            #endregion

            #region Consultando o usuário através do email

            var usuarioByEmailAndPassword = _usuarioRepository.GetByEmailAndSenha(usuario.Email,usuario.Senha);

            #endregion

            #region Verificando se o usuário foi retornado na consulta

            usuarioByEmailAndPassword.Should().NotBeNull();
            usuarioByEmailAndPassword.Nome.Should().Be(usuario.Nome);
            usuarioByEmailAndPassword.Email.Should().Be(usuario.Email);
            usuarioByEmailAndPassword.Senha.Should().Be(usuario.Senha);

            #endregion
        }
        private Usuario CreateUsuario()
        {
            var faker = new Faker("pt_BR");

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = $"@{faker.Internet.Password(10)}",
                DataHoraCriacao = DateTime.Now
            };

            _usuarioRepository.Create(usuario);
            return usuario;
        }


    }
    
}
