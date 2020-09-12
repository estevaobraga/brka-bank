using System.Collections.Generic;
using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Contas.Repository.Abstrations;
using Brka.Bank.Contas.Service.Abstrations;

namespace Brka.Bank.Contas.Service
{
    public class TransacoesService : ITransacoesService
    {
        private readonly ITransacoesRepository _transacoesRepository;
        
        public TransacoesService(ITransacoesRepository transacoesRepository)
        {
            _transacoesRepository = transacoesRepository;
        }

        public Task<ICollection<Transacao>> ConsultaExtratoContaCorrente(Conta conta)
        {
            return _transacoesRepository.ObtemTransacoesPorId(conta.Id, conta.IdUsuario);
        }
    }
}