using System.Collections.Generic;
using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Service.Abstrations
{
    public interface ITransacoesService
    {
        Task<ICollection<Transacao>> ConsultaExtratoContaCorrente(Conta conta);
    }
}