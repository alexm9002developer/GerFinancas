using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Data;
using Microsoft.EntityFrameworkCore;
using GerFinancas.Servico;
using Microsoft.AspNetCore.Http;
using GerFinancas.Acesso;

namespace GerFinancas
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
            services.AddControllersWithViews();
            services.AddEntityFrameworkMySql().AddDbContext<GerFinancasContext>(options =>
            options.UseMySql(connectionString: Configuration.GetConnectionString("DataBase"), new MySqlServerVersion(new Version(5, 6, 41)), builder => builder.MigrationsAssembly("GerFinancas")));
            //, Configuration.GetConnectionString("DataBase"));

            //Linhas 31 e 32 configuram a comunica��o com o servidor.

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartoesServicos, CartoesServico>();
            services.AddScoped<ITipoLancamentoServicos, TipoLancamentoServicos>();
            services.AddScoped<IFormatoLancamentoServicos, FormatoLancamentoServicos>();
            services.AddScoped<IUsuarioLoginServicos, UsuarioLoginServicos>();
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<IEmail, Email>();
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
        }

        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<GerFinancasContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("GerFinancasContext"), builder =>
                    builder.MigrationsAssembly("GerFinancas")));
                    //options.UseSqlServer(Configuration.GetConnectionString("GerFinancasContext")));
        }*/


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
