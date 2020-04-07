using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Site01.Database;

namespace Site01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<DatabaseContext>(options=> {
                //Providers - Biblioteca Conexões com Bancos - SQLServcer, MYSQL, Oracle, Postgre, Firebird, DB2...
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=site01;Integrated Security=True;");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /**
            * www.site.com.br/cliente/lista (Página com Listagem Clientes)
            * www.site.com.br/cliente/deletar/30 
            * www.site.com.br/cliente/visualizar/30 
            * www.site.com.br/noticia/visualizar/acidentes-de-carro-nas-rodovias
            * {dominio}/{controller=Home}/{Action=Index}/{id?} no id tbm pode ser nome e existe alguns valores padrão
            */
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
        }
    }
}
