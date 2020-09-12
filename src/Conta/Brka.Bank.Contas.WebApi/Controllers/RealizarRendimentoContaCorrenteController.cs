using System.Threading.Tasks;
using Brka.Bank.Contas.Service.Abstrations;
using Microsoft.AspNetCore.Mvc;

namespace Brka.Bank.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealizarRendimentoContaCorrenteController : ControllerBase
    {
        [HttpPut]
        public async Task Put([FromServices] IRendimentosService rendimentosService)
        {
            await rendimentosService.AplicaRendimentoContaCorrenteCdiDoDia();
        }
    }
}