using System.Collections.Generic;
using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Repository.Abstrations
{
    public interface ITransacoesRepository
    {
        Task<ICollection<Transacao>> ObtemTransacoesPorId(int idConta, int idUsuario);
        Task CadastraTransacao(Transacao transacao);
    }
}