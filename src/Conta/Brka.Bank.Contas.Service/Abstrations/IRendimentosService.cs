using System.Threading.Tasks;

namespace Brka.Bank.Contas.Service.Abstrations
{
    public interface IRendimentosService
    {
        Task AplicaRendimentoContaCorrenteCdiDoDia();
    }
}