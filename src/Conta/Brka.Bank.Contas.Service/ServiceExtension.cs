using Brka.Bank.Contas.Repository.Abstrations;
using Brka.Bank.Contas.Repository.Contas;
using Brka.Bank.Contas.Repository.Transacoes;
using Brka.Bank.Contas.Service.Abstrations;
using Microsoft.Extensions.DependencyInjection;

namespace Brka.Bank.Contas.Service
{
    public static class ServiceExtension
    {
        public static void InjectBuilderProperties(this IServiceCollection services)
        {
            #region AddServices

            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<ITransacoesService, TransacoesService>();
            services.AddScoped<IHttpRequestGateway, HttpRequestGateway>();
            services.AddScoped<IRendimentosService, RendimentosService>();

            #endregion

            #region AddRepositories

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ITransacoesRepository, TrasacoesRepository>();

            #endregion
        }
    }
}