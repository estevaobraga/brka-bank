using AutoMapper;
using Brka.Bank.Contas.Repository;
using Brka.Bank.Contas.Repository.Contas.Profiles;
using Brka.Bank.Contas.Repository.Transacoes.Profiles;
using Brka.Bank.Contas.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartupBase = Brka.Bank.Lib.WebApi.StartupBase;

namespace Brka.Bank.Contas.WebApi
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
        
        public override void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ContaCorrenteProfile());
                mc.AddProfile(new TransacoesProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            base.ConfigureServices(services);

            services.InjectBuilderProperties();

            services.AddDbContext<Context>(o => o.UseMySql(DataBaseConf.ConnectionString));
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            if (env.IsDevelopment() || env.IsProduction())
            {
                RentabilizaCdi.Start();
            }
        }
    }
}