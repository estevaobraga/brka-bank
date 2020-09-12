using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Repository.Abstrations;
using Brka.Bank.Contas.Service.Abstrations;

namespace Brka.Bank.Contas.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITransacoesRepository _transacoesRepository;

        public ContaService(IContaRepository contaRepository, ITransacoesRepository transacoesRepository)
        {
            _contaRepository = contaRepository;
            _transacoesRepository = transacoesRepository;
        }

        public async Task DepositarEmContaCorrente(Conta conta, decimal valor)
        {
            var contaCorrente = await _contaRepository.ObtemContaCorrente(conta);
            var transacao = new Transacao()
                .AdicionaContaCorrente(contaCorrente)
                .AdicinaOperacaoTrasacao(TipoTransacao.Credito, valor);
            contaCorrente.CreditoEmConta(valor);

            await _contaRepository.AtualizarContaCorrente(contaCorrente);
            await _transacoesRepository.CadastraTransacao(transacao);
        }

        public async Task ResgateEmContaCorrente(Conta conta, decimal valor)
        {
            var contaCorrente = await _contaRepository.ObtemContaCorrente(conta);
            var trasacao = new Transacao()
                .AdicionaContaCorrente(contaCorrente)
                .AdicinaOperacaoTrasacao(TipoTransacao.Debito, valor);
            contaCorrente.DebitoEmConta(valor);
            
            await _contaRepository.AtualizarContaCorrente(contaCorrente);
            await _transacoesRepository.CadastraTransacao(trasacao);
        }

        public async Task PagamentoComContaCorrente(Conta conta, string boleto, decimal valor)
        {
            var contaCorrente = await _contaRepository.ObtemContaCorrente(conta);
            var transacao = new Transacao()
                .AdicionaContaCorrente(contaCorrente)
                .AdicinaOperacaoTrasacao(TipoTransacao.Debito, valor);
            contaCorrente.PagamentoBoleto(boleto, valor);
            
            await _contaRepository.AtualizarContaCorrente(contaCorrente);
            await _transacoesRepository.CadastraTransacao(transacao);
        }

        public async Task<ContaCorrente> ConsultaContaCorrente(Conta conta)
        {
            return await _contaRepository.ObtemContaCorrente(conta);
        }
    }
}