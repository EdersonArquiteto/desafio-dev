using AutoMapper;
using EOS.CNAB.Application.DTO;
using EOS.CNAB.Domain.Entities;

namespace EOS.CNAB.Application.Mappings
{
    public class UsuarioDtoToEntity : Profile
    {
        public UsuarioDtoToEntity()
        {
            CreateMap<CriarUsuarioInput, Usuario>()
          .AfterMap((Commands, entity) =>
          {
              entity.Id = Guid.NewGuid();
              entity.DataHoraCriacao = DateTime.Now;
          });
        }
    }
}
