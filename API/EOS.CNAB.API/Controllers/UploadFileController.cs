using EOS.CNAB.Application.Interface;
using EOS.CNAB.Domain.Validations.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

namespace EOS.CNAB.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly ICNABAppService _cnabAppService;

        public UploadFileController(ICNABAppService cnabAppService)
        {
            _cnabAppService = cnabAppService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    while(!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                       await _cnabAppService.ReadTxtFile(line);
                       
                    }
                   
                }
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                var response = new Response();
                if (response.Report.Any()) {
                    return UnprocessableEntity(response.Report);
                }
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LoadData()
        {
            var cnabs = await _cnabAppService.GetAll();
            return StatusCode(200, cnabs);
        }
    }
}
