using System;
using Brka.Bank.Lib.WebApi.LoadingSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Brka.Bank.Lib.WebApi
{
    public class StartupBase
    {
        public StartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        protected DataBaseConf DataBaseConf => Configuration.GetSection("DataBaseConf").Get<DataBaseConf>();
        private SwashbuckleConf SwaggerConf => Configuration.GetSection("SwashbuckleConf").Get<SwashbuckleConf>();

        private const string AllowAllOriginsPolicy = "AllowAllOriginsPolicy";
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllOriginsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
            
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConf.Version,
                    new OpenApiInfo
                    {
                        Title = SwaggerConf.ApiName, Version = SwaggerConf.Version,
                        Contact = new OpenApiContact
                        {
                            Name = SwaggerConf.MadeBy, Email = SwaggerConf.Email,
                            Url = new Uri(SwaggerConf.UriWebSite)
                        },
                        Description = SwaggerConf.ApiDescription
                    });
            });
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(AllowAllOriginsPolicy);
            app.UseSwagger();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwaggerUI(c => { c.SwaggerEndpoint(SwaggerConf.PathSwagger, SwaggerConf.ApiDefinition); });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}