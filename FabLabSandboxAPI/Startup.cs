using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabLabSandboxAPI.Data;
using FabLabSandboxAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;
using System.IO;
using System.Text;
using FabLabSandboxAPI.Authorization.AuthenticationDB;
using Newtonsoft.Json.Serialization;
using FabLabSandboxAPI.Data.MachineData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FabLabSandboxAPI
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
            services.AddDbContext<MakerSpaceContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("MakerSpaceConnection")));
            //Authorization context
            /*services.AddDbContext<AuthorizationDBContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("AutorConnection")));*/

            services.AddControllers();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MakerSpaceContext>()
                .AddDefaultTokenProviders();
            //Adding Authentification
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                //Add Jwt Baerer
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes((Configuration["JWT:Secret"])))
                    };
                });
            //Add Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson(s =>
                       {
                           s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                       });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IMakerSpaceRepo, SqlMakerSpaceRepo>(); // needed
            services.AddScoped<IMachineRepo, SqlMachineRepo>();       // needed
            services.AddScoped<IMakerSpaceService, MakerSpaceService>();
            services.AddScoped<MachineService>();

            //Add Swagger
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger for FabLab",
                    Description = "Swagger for show endpoints and propertis needed for Api",
                    Version = "v1"
                });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                opt.IncludeXmlComments(filePath, true);
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
           {
               opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger for FabLab");
               opt.RoutePrefix = ""; // change in development!
           }
           );
        }
    }
}
