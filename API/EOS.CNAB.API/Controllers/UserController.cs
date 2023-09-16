using EOS.CNAB.Application.DTO;
using EOS.CNAB.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EOS.CNAB.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UserController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CriarUsuarioInput criarUsuario)
        {
            _usuarioAppService.CriarUsuario(criarUsuario);
            return StatusCode(201, new
            {
                messager = "usuario cadastrado com sucesso",
                criarUsuario
            });
        }

        [HttpPost]
        public IActionResult Authenticate(AutenticarUsuarioInput autenticarUsuario)
        {
            var model = _usuarioAppService.AutenticarUsuario(autenticarUsuario);

            return StatusCode(200, new
            {
                message = "Usuário autenticado com sucesso.",
                model
            });
        }
    }
}
