using AutoMapper;
using EOS.CNAB.Application.DTO;
using EOS.CNAB.Application.Interface;
using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Models;
using EOS.CNAB.Domain.Services;
using FluentValidation;

namespace EOS.CNAB.Application.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        public async Task CriarUsuario(CriarUsuarioInput criarUsuario)
        {
            var usuario = _mapper.Map<Usuario>(criarUsuario);
            var validate = usuario.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            _usuarioDomainService.CriarUsuario(usuario);
        }

        public async Task<AuthorizationModel> AutenticarUsuario(AutenticarUsuarioInput autenticarUsuario)
        {
            var model = _usuarioDomainService.AutenticarUsuario(autenticarUsuario.Email, autenticarUsuario.Senha);
            return model;
        }

    }
}
