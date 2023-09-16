using EOS.CNAB.Domain.Core;
using EOS.CNAB.InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.InfraStructure.Repository
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly SqlServerContext _sqlServerContext;

        protected Repository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public virtual void Create(TEntity obj)
        {
            _sqlServerContext.Add(obj);
            _sqlServerContext.SaveChanges();

        }

        public async Task<IList<TEntity>> GetAll()
        {
            return _sqlServerContext.Set<TEntity>().ToList();
        }
    }
}
