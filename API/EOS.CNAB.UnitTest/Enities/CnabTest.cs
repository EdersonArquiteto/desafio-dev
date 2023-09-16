using EOS.CNAB.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace EOS.CNAB.UnitTest.Enities
{
    public class CnabTest
    {
        [Fact]
        public void ValidarIdTest()
        {
            var cnab = new Cnab()
            {
                Id = Guid.Empty
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarCPFTest()
        {
            var cnab = new Cnab
            {
                CPF = string.Empty,
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("CPF é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarCardTest()
        {
            var cnab = new Cnab
            {
                Card = string.Empty,
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Card é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarOwnerTest()
        {
            var cnab = new Cnab
            {
                Owner = string.Empty,
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Owner é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarStoreNameTest()
        {
            var cnab = new Cnab
            {
                StoreName = string.Empty,
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("StoreName é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarValueTest()
        {
            var cnab = new Cnab
            {
                Value = decimal.Negate(decimal.MaxValue)
            };

            cnab.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("value não pode ser negativo"))
                .Should()
                .NotBeNull();
        }
    }
}
