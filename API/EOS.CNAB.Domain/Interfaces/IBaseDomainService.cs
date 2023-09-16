using EOS.CNAB.Domain.Validations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Interfaces
{
    public interface IBaseDomainService<TEntity, Guid> where TEntity : class
    {
        Task<Response> Adicionar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
    }
}
