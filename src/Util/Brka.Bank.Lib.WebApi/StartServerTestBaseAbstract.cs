using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Brka.Bank.Lib.WebApi
{
    public abstract class StartServerTestBaseAbstract<TStartup> : IClassFixture<WebApplicationFactory<TStartup>> where TStartup : StartupBase
    {
        protected HttpClient Client;
        protected IHost Host;
        
        protected StartServerTestBaseAbstract()
        {
            var hostBuilder =  new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseEnvironment("Test");
                    webHost.UseTestServer();
                    webHost.UseStartup<TStartup>().ConfigureAppConfiguration(conf => conf.AddJsonFile("appsettings.Development.json"));
                });

            var host = hostBuilder.Start();
            Host = host;
            Client = Host.GetTestClient();
        }
    }
}