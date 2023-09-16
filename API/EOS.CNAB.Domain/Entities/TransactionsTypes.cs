using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Entities
{
    public enum TransactionsTypes
    {
      
        Debito ,
        Boleto,
        Financiamento,
        Credito,
        Recebimento_Emprestimo,
        Vendas,
        Recebimento_TED,
        Recebimento_DOC,
        Aluguel
    }
}
