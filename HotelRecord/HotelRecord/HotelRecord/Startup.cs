using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HotelRecord.Repository;
using HotelRecord.Repository.Interfaces;
using HotelRecord.Repository.Repositories;
using HotelRecord.BussinessLogic.Interfaces;
using HotelRecord.BussinessLogic.Services;
using AutoMapper;

namespace HotelRecord
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

            var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelRecord;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True;";
            services.AddDbContext<HotelRecordDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IHotelChainRepository, HotelChainRepository>();
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IHotelChainService, HotelChainService>();

            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
