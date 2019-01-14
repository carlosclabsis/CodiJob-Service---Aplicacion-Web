using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodiJobServices.Model;
using Domain;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Domain.IRepositories;
using Application.IServices;
using Application.Services;
using Infraestructure.Repositories;
using Infraestructure.Persistencia;
using Application.DTOs;
using Infraestructure.Transversal.FluentValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Transversal.Authenticacion;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infraestructure.Transversal.Swagger;

namespace CodiJobServices
{
    public class Startup
    {
        //Iniciando configuracion
        //Prueba Github
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CodiJobDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:CodiJob:ConnectionString"],
                     b => b.MigrationsAssembly("CodiJobServices")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:CodiJobIdentity:ConnectionString"]
                    ));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            //INYECCION POR DEPENDENCIA
            // REPOSITORIOS
            services.AddTransient<IProyectoRepository, EFProyectoRepository>();
            services.AddTransient<ISkillRepository, EFSkillRepository>();
            services.AddTransient<IGrupoRepository, EFGrupoRepository>();
            services.AddTransient<IUsuarioperfilRepository, EFUsuarioperfilRepository>();
            //SERVICIOS
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<IGrupoService, GrupoService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IUsuarioperfilService, UsuarioperfilService>();
            services.AddTransient<IUserService, UserService>();

            //Validators
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();
            services.AddTransient<IValidator<SkillDTO>, SkillDTOValidator>(); 
            services.AddTransient<IValidator<GrupoDTO>, GrupoDTOValidator>();
            services.AddTransient<IValidator<UsuarioperfilDTO>, UsuarioperfilDTOValidator>();

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "CodiJobServices", Version = "v1" });
            });

            services.AddSwaggerDocumentation();

            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerDocumentation();
            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
