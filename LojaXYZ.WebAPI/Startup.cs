using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Application.Application;
using LojaXYZ.Application.Interfaces;
using LojaXYZ.Domain.Services;
using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Repository;
using LojaXYZ.Infrastructure.Repository.Generics;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LojaXYZ.WebAPI.Token;
using System;
using System.Threading.Tasks;

namespace LojaXYZ.WebAPI
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

            services.AddDbContext<Context>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Context>();

            //Interface e Repositorios - Injeççao de Dependencia
            services.AddScoped(typeof(IGenerics<>), typeof(RepositoryGeneric<>));
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuario, UsuarioRepository>();

            //Service Dominio - Injeção de Dependencia
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICarrinhoService, CarrinhoService>();
            services.AddScoped<IITemCarrinhoService, ItemCarrinhoService>();


            //Interface Aplicaçao - Injeção de Dependencia
            services.AddScoped<IApplicationProduto, ApplicationProduto>();
            services.AddScoped<IApplicationCliente, ApplicationCliente>();
            services.AddScoped<IApplicationCarrinho, ApplicationCarrinho>();
            services.AddScoped<IApplicationItemCarrinho, ApplicationItemCarrinho>();
            services.AddScoped<IApplicationUsuario, ApplicationUsuario>();


            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "LojaXYZ",
                    ValidAudience = "LojaXYZ",
                    IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")

                };

                op.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValid: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });



            services.AddScoped<SeedingProdutos>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LojaXYZ.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingProdutos seedingProdutos)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingProdutos.Seed();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaXYZ.WebAPI v1"));
            }

            app.UseHttpsRedirection();

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
