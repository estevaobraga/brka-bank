using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quartz;

namespace Brka.Bank.Contas.WebApi
{
    public class RentabilizaContaCorrenteCdiFechamentoJob : IJob
    {
        private const string RealizaRendimentoContaCorrente = "http://localhost:5000/RealizarRendimentoContaCorrente";
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(RealizaRendimentoContaCorrente);

                if (response.IsSuccessStatusCode)
                {
                    JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());
                    await Console.Out.WriteLineAsync("Contas correntes rentabilizadas com sucesso! 100% do CDI :)");
                }
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync("ERRO ao rentabilizar CDI em contas correntes: " + e.Message);
            }
        }
    }
}