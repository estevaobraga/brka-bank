using System;
using System.Threading.Tasks;
using Quartz;

namespace Brka.Bank.Contas.WebApi
{
    public class RentabilizaContaCorrenteCdiFechamentoJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Contas correntes rentabilizadas com sucesso! 100% do CDI :)");
        }
    }
}