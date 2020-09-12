using System.Threading.Tasks;

namespace Brka.Bank.Contas.Service.Abstrations
{
    public interface IHttpRequestGateway
    {
        Task<decimal> ObtemTaxaCdiDia();
    }
}