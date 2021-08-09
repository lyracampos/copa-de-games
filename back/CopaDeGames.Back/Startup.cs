using CopaDeGames.Back.Domain.Repositories.Apis;
using CopaDeGames.Back.Domain.Repositories.Data;
using CopaDeGames.Back.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CopaDeGames.Back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                     builder => builder
                         .SetIsOriginAllowed(s => true)
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .AllowCredentials());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CopaDeGames.Back", Version = "v1" });
            });

            services.AddTransient<ICampeonatoService, CampeonatoService>();
            services.AddTransient<IApiLambdaCompetidores, ApiLambdaCompetidores>();
            services.AddTransient<ICampeonatoRepository, CampeonatoRepository>();
            services.AddDbContext<DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopaDeGames.Back v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
