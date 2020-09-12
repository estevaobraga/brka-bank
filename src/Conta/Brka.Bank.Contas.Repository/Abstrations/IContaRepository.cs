using System.Collections.Generic;
using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Repository.Abstrations
{
    public interface IContaRepository
    {
        Task CriaContaCorrente(ContaCorrente conta);
        Task AtualizarContaCorrente(ContaCorrente conta);
        Task<ContaCorrente> ObtemContaCorrente(Conta conta);
        Task<ICollection<ContaCorrente>> OntemContas();
    }
}