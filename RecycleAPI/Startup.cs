using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RecycleAPI.Services;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using RecycleAPI.Controllers;
using RecycleAPI.Repository;

namespace RecycleAPI
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
            services.AddMvc()
                 .AddJsonOptions(a =>
                 {
                     a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                 });

            services.AddDbContext<APIContext>(options => options.UseSqlServer("Server=(local);Initial Catalog=RecycleDb;User Id=sa;Password=masterkey"));

            services.AddTransient<IVendorsRepository, VendorsRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IVendorService, VendorService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Orders API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders API");
            });

            app.UseMvc();
        }
    }
}
