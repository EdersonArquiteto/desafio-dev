using EOS.CNAB.Domain.Entities;
using System.Text.Json.Serialization;

namespace EOS.CNAB.Application.DTO
{
    public class CNABOutput
    {
        public Guid Id { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionsTypes TipoOcorrencia { get; set; }
       
        //public int TipoOcorrencia { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public DateTime Time { get; set; }
        public string Owner { get; set; }
        public string StoreName { get; set; }
    }
}
