using System;
using System.Text;
using EmployeeAPIException.Repository;
using EmployeeAPIJWT.Data;
using EmployeeAPIJWT.Middleware;
using EmployeeAPIJWT.Repository;
using EmployeeAPIJWT.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EmployeeAPIJWT
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Load JWT settings from appsettings.json
            var jwtConfig = _configuration.GetSection("JWT");
            string secretKey = jwtConfig["Key"];
            string issuer = jwtConfig["Issuer"];
            string audience = jwtConfig["Audience"];
            int expiryInMinutes = int.Parse(jwtConfig["ExpiryInMinutes"]);

            // Add JWT Bearer Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            // Register TokenService using configuration values for issuing JWT tokens
            services.AddSingleton(new TokenService(secretKey, issuer, audience, expiryInMinutes));

            // Add controllers and Swagger for API documentation
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeAPIJWT", Version = "v1" });
                // Optional: Enable authorization in Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            // Database context registration for SQL Server
            services.AddDbContext<EmployeeJWTDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper for object mapping
            services.AddAutoMapper(typeof(Startup));

            // Register repository pattern for Employee data
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Optionally add authorization policies (if any specific policy is needed)
            services.AddAuthorization(options =>
            {
                // Example of custom policy (optional):
                // options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeAPIJWT v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Ensure the authentication middleware runs before authorization
            app.UseAuthentication(); // Validate the JWT token and set the user context

            // Use authorization middleware to enforce access control
            app.UseAuthorization();  // Check if the user is authorized for the endpoint

            // Custom exception handling middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
