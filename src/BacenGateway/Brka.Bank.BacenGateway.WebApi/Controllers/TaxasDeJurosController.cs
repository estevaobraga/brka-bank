using System.Threading.Tasks;
using Brka.Bank.BacenGateway.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Brka.Bank.BacenGateway.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxasDeJurosController : ControllerBase
    {
        [HttpGet("Cdi")]
        public async Task<IActionResult> GetCdi()
        {
            return Ok(await Task.Run(() => new TaxaDeJuros().Cdi));
        }
        
        [HttpGet("CdiDia")]
        public async Task<IActionResult> GetCdiDia()
        {
            return Ok(await Task.Run(() => new TaxaDeJuros().CdiDia));
        }
 
        [HttpGet("Selic")]
        public async Task<IActionResult> GetSelic()
        {
            return Ok(await Task.Run(() => new TaxaDeJuros().Selic));
        }
    }
}