using System.Threading.Tasks;
using Brka.Bank.Contas.Repository.Abstrations;
using Brka.Bank.Contas.Service.Abstrations;

namespace Brka.Bank.Contas.Service
{
    public class RendimentosService : IRendimentosService
    {
        private readonly IHttpRequestGateway _httpRequestGateway;
        private readonly IContaRepository _contaRepository;

        public RendimentosService(IHttpRequestGateway httpRequestGateway, IContaRepository contaRepository)
        {
            _httpRequestGateway = httpRequestGateway;
            _contaRepository = contaRepository;
        }

        public async Task AplicaRendimentoContaCorrenteCdiDoDia()
        {
            var cdi = await _httpRequestGateway.ObtemTaxaCdiDia();
            
            throw new System.NotImplementedException();
        }
    }
}