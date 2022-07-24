using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WitchSaga.Application.Services.Victim;

namespace WitchSaga.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adding custom dependency class
            services.AddTransient<IKillingManager, KillingManager>();
            services.AddTransient<IVictimService, VictimService>();

            services.AddControllers();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Witch Saga Simple Test Api",
                    Description = "Witch Saga Simple Test Api"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
               .UseSwaggerUI(option =>
               {
                   option.RoutePrefix = "swagger/ui";
                   option.SwaggerEndpoint("/swagger/v1/swagger.json", "WS Absensi Api V1");
               });

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });
        }
    }
}
