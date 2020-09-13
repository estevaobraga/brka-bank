using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Repository.Abstrations;
using Brka.Bank.Contas.Service.Abstrations;

namespace Brka.Bank.Contas.Service
{
    public class RendimentosService : IRendimentosService
    {
        private readonly IHttpRequestGateway _httpRequestGateway;
        private readonly IContaRepository _contaRepository;
        private readonly ITransacoesRepository _transacoesRepository;

        public RendimentosService(IHttpRequestGateway httpRequestGateway, IContaRepository contaRepository, ITransacoesRepository transacoesRepository)
        {
            _httpRequestGateway = httpRequestGateway;
            _contaRepository = contaRepository;
            _transacoesRepository = transacoesRepository;
        }

        public async Task AplicaRendimentoContaCorrenteCdiDoDia()
        {
            var cdi = await _httpRequestGateway.ObtemTaxaCdiDia();
            var contasCorrentes = await _contaRepository.OntemContas();

            foreach (var contaCorrente in contasCorrentes)
            {
                var transacao = new Transacao();
                transacao.AdicionaContaCorrente(contaCorrente);
                
                var saldo = contaCorrente.Saldo;
                var valorRendimento = (saldo * cdi) / saldo;
                contaCorrente.CreditoEmConta(valorRendimento);

                await _contaRepository.AtualizarContaCorrente(contaCorrente);
                
                transacao.AdicinaOperacaoTrasacao(TipoTransacao.Credito, valorRendimento);
                await _transacoesRepository.CadastraTransacao(transacao);
            }
        }
    }
}