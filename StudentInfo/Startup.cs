using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.HesapServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace StudentInfo
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
           // services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<StdContext>(item => item.UseSqlServer(Configuration.GetConnectionString("StudentDb"), options => { }));

            services.AddTransient<IShipmentRepository, EfCoreShippment>();
            services.AddTransient<IShippmentPackageRepository, EfCoreShippmentPackage>();
            services.AddTransient<IWeightAndSizeRepository, EfCoreWeightAndSize>();

            services.AddTransient<IShippmentServices, ShippmentManager>();
            services.AddTransient<IShippmentPackageServices, ShipmentPackageManager>();
            services.AddTransient<IWeightAndSizeServices, WeightAndSizeManager>();
            services.AddTransient<ShippingCalculator>();
            services.AddTransient<TrackingResponse>();
            
            


            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(o => o.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            

        }
    }
}
