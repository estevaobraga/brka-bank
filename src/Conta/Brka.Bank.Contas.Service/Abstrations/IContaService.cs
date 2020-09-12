using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Service.Abstrations
{
    public interface IContaService
    {
        Task DepositarEmContaCorrente(Conta conta, decimal valor);
        Task ResgateEmContaCorrente(Conta conta, decimal valor);
        Task PagamentoComContaCorrente(Conta conta, string boleto, decimal valor);
        Task<ContaCorrente> ConsultaContaCorrente(Conta conta);
    }
}