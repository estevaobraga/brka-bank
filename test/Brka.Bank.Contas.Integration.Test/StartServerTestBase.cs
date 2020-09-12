using Brka.Bank.Contas.Repository;
using Brka.Bank.Contas.Service.Abstrations;
using Brka.Bank.Contas.WebApi;
using Brka.Bank.Lib.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;

namespace Brka.Bank.Contas.Integration.Test
{
    public class StartServerTest : StartServerTestBaseAbstract<Startup>
    {
        protected readonly Context Context;

        public StartServerTest()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseEnvironment("Test");
                    webHost.UseTestServer();

                    webHost.UseStartup<Startup>().ConfigureServices((context, services) =>
                        {
                            services.RemoveAll<IHttpRequestGateway>();
                            
                            var gateway = new Mock<IHttpRequestGateway>();
                            gateway.Setup(x => x.ObtemTaxaCdiDia()).ReturnsAsync((decimal) 0.007);

                            services.AddSingleton(_ => gateway.Object);
                        })
                        .ConfigureAppConfiguration(conf => conf.AddJsonFile("appsettings.Development.json"));
                });

            var host = hostBuilder.Start();
            Host = host;
            Client = Host.GetTestClient();

            Context = Host.Services.GetService<Context>();
        }
    }
}