using Bogus;
using Bogus.Extensions.Brazil;
using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using Xunit;

namespace EOS.CNAB.UnitTest.Services
{
    public class CNABDomainServiceTest
    {
        private readonly ICNABDomainService _cnabDomainService;

        public CNABDomainServiceTest(ICNABDomainService cnabDomainService)
        {
            _cnabDomainService = cnabDomainService;
        }

        [Fact]
        public async Task TestCreate()
        {
            var cnab = NewCnab();
            _cnabDomainService.Adicionar(cnab);


            await Assert.ThrowsAsync<DomainException>(() => _cnabDomainService.Adicionar(cnab));
        }

        private Cnab NewCnab()
        {
            var faker = new Faker("pt_BR");

            return new Cnab
            {
                Id = Guid.NewGuid(),
                Type =(TransactionsTypes) 1,
                Date = faker.Date.Recent(20),
                Value = faker.Random.Decimal(100, 5000),
                CPF = faker.Person.Cpf(),
                Card = "674965410701",
                Time = faker.Date.Recent(20),
                Owner = faker.Person.FirstName,
                StoreName = faker.Company.CompanyName()

            };
        }

        private TransactionsTypes NewTransactionTypes()
        {
            var faker = new Faker("pt_BR");

            return new TransactionsTypes { };
        }


    }
}
