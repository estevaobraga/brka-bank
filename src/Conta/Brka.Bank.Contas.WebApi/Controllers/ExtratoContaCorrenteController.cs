using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Service.Abstrations;
using Microsoft.AspNetCore.Mvc;

namespace Brka.Bank.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtratoContaCorrenteController : ControllerBase
    {
        private readonly ITransacoesService _transacoesService;

        public ExtratoContaCorrenteController(ITransacoesService transacoesService)
        {
            _transacoesService = transacoesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _transacoesService.ConsultaExtratoContaCorrente(new ContaCorrente {Id = 1, IdUsuario = 1}));
        }
    }
}