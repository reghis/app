using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
//using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.Extensions.Configuration;


namespace WebConsola.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "WebConsola.xml");

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info
                {
                    Title = "UpCurAPI Swagger Reghisbot MVC Net.Core",
                    Version = "v1"
                });
                config.IncludeXmlComments(xmlPath);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                config.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                config.AddSecurityRequirement(securityRequirement);

                // Seguridad del Documento
            }
            );
            // VERSION 2 se hara afuera en Startup
            return services;
        }
        //registra en la Aplicacion
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UpCur Swagger Reghisbot MVC Net.Core");

            });
            return app;
        }

    }
}
