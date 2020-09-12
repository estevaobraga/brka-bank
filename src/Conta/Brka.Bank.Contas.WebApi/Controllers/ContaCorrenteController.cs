using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Service.Abstrations;
using Microsoft.AspNetCore.Mvc;

namespace Brka.Bank.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaCorrenteController(IContaService contaService)
        {
            _contaService = contaService;
        }

        /// <summary>
        /// Consulta conta corrente
        /// </summary>
        /// <returns></returns>
        [HttpGet("{codigoAgencia}/{numero}/{digito}")]
        public async Task<IActionResult> Get(int codigoAgencia, int numero, int digito)
        {
            return Ok(await _contaService.ConsultaContaCorrente(new ContaCorrente
            {
                CodigoAgencia = codigoAgencia,
                Numero = numero,
                Digito = digito
            }));
        }

        /// <summary>
        /// Deposito em conta corrente
        /// </summary>
        /// <returns></returns>
        [HttpPut("Deposito")]
        public async Task<IActionResult> PutDeposito([FromForm] int codigoAgencia, [FromForm] int numero, [FromForm] int digito, [FromForm] decimal valor)
        {
            await _contaService.DepositarEmContaCorrente(new ContaCorrente
            {
                CodigoAgencia = codigoAgencia,
                Numero = numero,
                Digito = digito
            }, valor);
            return Ok();
        }
        
        /// <summary>
        /// Resgate em conta corrente
        /// </summary>
        /// <returns></returns>
        [HttpPut("Resgate")]
        public async Task<IActionResult> PutResgate([FromForm] int codigoAgencia, [FromForm] int numero, [FromForm] int digito, [FromForm] decimal valor)
        {
            await _contaService.ResgateEmContaCorrente(new ContaCorrente
            {
                CodigoAgencia = codigoAgencia,
                Numero = numero,
                Digito = digito
            }, valor);
            return Ok();
        }
        
        /// <summary>
        /// Pagamento de boleto
        /// </summary>
        /// <returns></returns>
        [HttpPut("PagarBoleto")]
        public async Task<IActionResult> PutBoleto([FromForm] int codigoAgencia, [FromForm] int numero, [FromForm] int digito, [FromForm] decimal valor, [FromForm] string boleto)
        {
            await _contaService.PagamentoComContaCorrente(new ContaCorrente
            {
                CodigoAgencia = codigoAgencia,
                Numero = numero,
                Digito = digito
            }, boleto, valor);
            return Ok();
        }
    }
}