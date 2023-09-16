using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.InfraStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.InfraStructure.Repository
{
    public class CNABRepository : Repository<Cnab, int>, ICNABRepositori
    {
        public CNABRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
        }
    }
}
