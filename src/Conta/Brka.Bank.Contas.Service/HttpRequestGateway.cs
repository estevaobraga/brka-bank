using System.Net.Http;
using System.Threading.Tasks;
using Brka.Bank.Contas.Service.Abstrations;
using Newtonsoft.Json;

namespace Brka.Bank.Contas.Service
{
    public class HttpRequestGateway : IHttpRequestGateway
    {
        public async Task<decimal> ObtemTaxaCdiDia()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/TaxasDeJuros/CdiDia");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());

            throw new System.Exception("Erro na requisição da taxa");
        }
    }
}