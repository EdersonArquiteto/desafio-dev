using AutoMapper;
using EOS.CNAB.Application.DTO;
using EOS.CNAB.Application.Interface;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Services;
using EOS.CNAB.Domain.Validations.Base;

namespace EOS.CNAB.Application.Service
{
    public class CNABAppService : ICNABAppService
    {
        private readonly IMapper _mapper;
        private readonly CNABDomainService _cnabDomainService;

        public CNABAppService(IMapper mapper, CNABDomainService cnabDomainService)
        {
            _mapper = mapper;
            _cnabDomainService = cnabDomainService;
        }

        public async Task<List<CNABOutput>> GetAll()
        {
            var cnabs = await _cnabDomainService.ObterTodos();
            return _mapper.Map<List<CNABOutput>>(cnabs);
        }

        public async Task<Response> ReadTxtFile(string line)
        {

            var dados = new CNABInput
            {
                Type = int.Parse(line.Substring(0, 1)),
                Date = line.Substring(1, 8),
                Value = decimal.Parse(line.Substring(9, 10)) / 100.00M,
                CPF = line.Substring(19, 11),
                Card = line.Substring(30, 12),
                Time = line.Substring(42, 6),
                Owner = line.Substring(48, 14).Trim(),
                StoreName = line.Substring(61, 19).Trim()
            };

            dados.Value = decimal.Round(dados.Value, 2);
            var cnab = _mapper.Map<Cnab>(dados);
            try
            {
            return await _cnabDomainService.Adicionar(cnab);
               
            }catch(Exception ex)
            {
                var response = Report.Create(ex.Message);
                return Response.Unprocessable(response);
            }
             
            
        }
    }
}
