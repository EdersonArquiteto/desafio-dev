using EOS.CNAB.Application.DTO;
using EOS.CNAB.Domain.Validations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Application.Interface
{
    public interface ICNABAppService
    {
        Task<Response> ReadTxtFile(string file);
        Task<List<CNABOutput>> GetAll();
    }
}
