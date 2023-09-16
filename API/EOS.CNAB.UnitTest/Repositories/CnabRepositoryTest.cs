using Bogus;
using Bogus.Extensions.Brazil;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.InfraStructure.Repository;
using FluentAssertions;
using Xunit;

namespace EOS.CNAB.UnitTest.Repositories
{
    public class CnabRepositoryTest
    {
        private ICNABRepositori _cnabRepository;

        public CnabRepositoryTest(ICNABRepositori cnabRepository)
        {
            _cnabRepository = cnabRepository;
        }

        [Fact]
        public void TestCreate()
        {
            #region Realizando o cadastro de um usuário

            var cnab = CreateCnab();

            #endregion

            #region Verificando se o usuário foi cadastrado

            var cnabs = _cnabRepository.GetAll();

            for (var i=0; i< cnabs.Result.Count; i++)
            {
                var result = cnabs.Result[i];
                
                result.StoreName.Should().NotBeNull();
                result.CPF.Should().NotBeNull();
                result.Card.Should().NotBeNull();
                result.Owner.Should().NotBeNull();
                result.StoreName.Should().NotBeNull();
            }
          

        #endregion
    }

        private Cnab CreateCnab()
        {
            var faker = new Faker("pt_BR");

            var cnab = new Cnab
            {
                Id = Guid.NewGuid(),
                Type = (TransactionsTypes)1,
                Date = faker.Date.Recent(20),
                Value = faker.Random.Decimal(100, 5000),
                CPF = faker.Person.Cpf(),
                Card = "674965410701",
                Time = faker.Date.Recent(20),
                Owner = faker.Person.FirstName,
                StoreName = faker.Company.CompanyName()
            };

            _cnabRepository.Create(cnab);
            return cnab;
        }
    }
}
