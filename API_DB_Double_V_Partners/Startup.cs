using API_DB_Double_V_Partners.Servicios;
using API_DB_Double_V_Partners.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API_DB_Double_V_Partners
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
            services.AddControllers(opciones =>
                opciones.Conventions.Add(new SwaggerPorVersion())
            );

            services.AddTransient<IRepositorioPruebas, RepositorioPruebas>();
            services.AddTransient<IEncriptar, Encriptar>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Double V Partners", Version = "v1" })
            ) ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Double V Partners v1"); } 
                    
                );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
                endpoints.MapControllers()
            );
        }

    }
}
