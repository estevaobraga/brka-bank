using Brka.Bank.Contas.Repository;
using Brka.Bank.Contas.WebApi;
using Brka.Bank.Lib.WebApi;
using Microsoft.Extensions.DependencyInjection;

namespace Brka.Bank.Contas.Integration.Test
{
    public class StartServerTest : StartServerTestBaseAbstract<Startup>
    {
        protected readonly Context Context;
        public StartServerTest()
        {
            Context = Host.Services.GetService<Context>();
        }
    }
}