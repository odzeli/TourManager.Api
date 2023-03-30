using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TourManager.Api.Converters;
using TourManager.Domain;
using TourManager.Storage;

namespace TourManager.Api
{
    public class Startup
    {
        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private IConfiguration Configuration { get; }




        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            CurrentEnvironment = env;
            Configuration = configuration;
        }

        private readonly string localConnectionStringKey = "LocalConnection";
        private readonly string prodConnectionStringKey = "ProdConnection";
        private readonly string specificOrigins = "specificOrigin";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: specificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers();

            DiExtension.AddDI(services);

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new ColumnValueConverter());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            if (CurrentEnvironment.IsDevelopment())
                services.AddDbContext<TourManagerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(localConnectionStringKey)));
            else
                services.AddDbContext<TourManagerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(prodConnectionStringKey)));


            //var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false; // should be true on the production
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = authOptions.Issuer,

            //            ValidateAudience = true,
            //            ValidAudience = authOptions.Audience,

            //            ValidateLifetime = true,

            //            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(), // HS256
            //            ValidateIssuerSigningKey = true
            //        };
            //    });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromSeconds(5),
                        ValidateAudience = false
                    };
                    config.Authority = "https://localhost:44300";
                    config.Audience = "https://localhost:44300";
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TourManager.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TourManager.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(specificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
