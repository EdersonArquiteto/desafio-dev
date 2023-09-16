using AutoMapper;
using EOS.CNAB.Application.DTO;
using EOS.CNAB.Domain.Entities;
using System.Globalization;

namespace EOS.CNAB.Application.Mappings

{
    public class CNABProfile : Profile
    {
        public CNABProfile()
        {
            CreateMap<CNABInput, Cnab>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src=> DateTime.ParseExact(src.Date, "yyyyMMdd", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src=> DateTime.ParseExact(src.Time, "HHmmss", CultureInfo.InvariantCulture)))
                .ReverseMap();

            CreateMap<Cnab, CNABOutput>();

            CreateMap<CNABOutput, Cnab>()
                .ForMember(dest => (TransactionsTypes)dest.Type, opt=>opt.MapFrom(src => src.TipoOcorrencia))
                .ReverseMap();
                
        }
    }
}
