using AspNetCoreRateLimit;
using Catalog.Core;
using Catalog.Core.Services.Implementation;
using Catalog.Core.Services.Interfaces;
using Catalog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalog
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

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("sqlConnection") , b => b.MigrationsAssembly("Catalog"))
            );

            services.AddMemoryCache();

            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor();

          

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.ConfigureAutoMapper();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            services.ConfigureSwaggerDoc();

            services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.ConfigureVersioning();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Hotel Listing API");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();
            
            app.UseCors("AllowAll");

           
            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
