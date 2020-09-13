using System.Net.Http;
using System.Threading.Tasks;
using Brka.Bank.Contas.Service.Abstrations;
using Newtonsoft.Json;

namespace Brka.Bank.Contas.Service
{
    public class HttpRequestGateway : IHttpRequestGateway
    {
        private const string UrlTaxaCdi = "http://localhost:5001/TaxasDeJuros/CdiDia";
        public async Task<decimal> ObtemTaxaCdiDia()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(UrlTaxaCdi);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());

            throw new System.Exception("Erro na requisição da taxa");
        }
    }
}