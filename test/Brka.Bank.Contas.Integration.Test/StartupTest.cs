using Brka.Bank.Contas.Repository;
using Brka.Bank.Contas.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Brka.Bank.Contas.Integration.Test
{
    public class StartupTest : Startup
    {
        public StartupTest(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.RemoveAll<Context>();
            services.AddDbContext<Context>(x => x.UseInMemoryDatabase("brka"));
        }
    }
}