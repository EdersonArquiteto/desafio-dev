using EOS.CNAB.Domain.Core;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.Domain.Validations.Base;
using EOS.CNAB.Domain.Validations.Entites;

namespace EOS.CNAB.Domain.Services
{
    public class CNABDomainService : ICNABDomainService
    {
        private readonly ICNABRepositori _cnabRepositori;

        public CNABDomainService(ICNABRepositori cnabRepositori)
        {
            _cnabRepositori = cnabRepositori;
        }

        public async Task<Response> Adicionar(Cnab entity)
        {
            var response =new Response();
            var cnabValidation = new CnabValidation();
            var errosInCNAB = cnabValidation.Validate(entity).GetErrors();

            if (errosInCNAB.Report.Count > 0)
            {
                return errosInCNAB;
            }
            _cnabRepositori.Create(entity);
            return response;
        }

        public async Task<List<Cnab>> ObterTodos()
        {
            var cnabs = await _cnabRepositori.GetAll();
            return cnabs.ToList();
        }
    }
}
