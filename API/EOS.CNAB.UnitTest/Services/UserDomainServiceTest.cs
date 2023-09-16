using Bogus;
using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Services;
using Xunit;

namespace EOS.CNAB.UnitTest.Services
{
    public class UserDomainServiceTest
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UserDomainServiceTest(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        [Fact]
        public void TestCriarUsuario()
        {
            try
            {
                var usuario = NewUsuario();
                _usuarioDomainService.CriarUsuario(usuario);
            }
            catch (Exception e)
            {
                //Gerando um resultado de falha!
                Assert.Fail(e.Message);
            }
        }

        [Fact]
        public void TestEmailJaCadastrado()
        {
            var usuario = NewUsuario();
            _usuarioDomainService.CriarUsuario(usuario);

            //Definindo como critério para teste passar que a execução do método
            //deverá retornar uma exceção do tipo DomainException
            Assert.Throws<DomainException>(() => _usuarioDomainService.CriarUsuario(usuario));
        }

        private Usuario NewUsuario()
        {
            var faker = new Faker("pt_BR");

            return new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = $"@{faker.Internet.Password(10)}",
                DataHoraCriacao = DateTime.Now
            };
        }
    }
}
