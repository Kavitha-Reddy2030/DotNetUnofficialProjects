using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFilterAPI.Data;
using BookFilterAPI.Filters;
using BookFilterAPI.Mappings;
using BookFilterAPI.Middleware;
using BookFilterAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookFilterAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            /*services.AddControllers(options =>
            {
                options.Filters.Add<BookFilterActionFilter>(); // Add the custom filter globally
            });*/
            services.AddScoped<BookFilterActionFilter>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookFilterAPI", Version = "v1" });
            });
            services.AddDbContext<BookFilterDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));
           // services.AddAutoMapper(typeof(BookFilterProfile));

            // Register repository pattern for Employee data
            services.AddScoped<IBookFilterRepository, BookFilterRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookFilterAPI v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Or your custom error handling route
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
