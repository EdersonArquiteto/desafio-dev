using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Application.DTO
{
    public class CNABInput
    {
        public int Type { get; set; }
        public string Date { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public string Time { get; set; }
        public string Owner { get; set; }
        public string StoreName { get; set; }
    }
}
