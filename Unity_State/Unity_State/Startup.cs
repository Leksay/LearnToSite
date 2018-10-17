using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity_State.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Unity_State
{
    public class Startup
    {
        /*путь к корневой папке проекта */
        private string _contentRootPath = "";

        /*этот  вариант  инициализации  конфигурации  позволяет  получить и сохранить строку с путем к папке с файлами проекта*/
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
            _contentRootPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*Контекст  данных  в  виде  сервиса  позволит  получать его в конструкторе контроллера как входной параметр. 
             *С пом. Replace в строку инициализации подставляется актуальный путь к папке с базой данных. */
            string connection = Configuration.GetConnectionString("DefaultConnection");
            if (connection.Contains("%CONTENTROOTPATH%"))
            {
                connection = connection.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }

            services.AddDbContext<SiteContext>(options => options.UseSqlServer(connection));
            /**/
            services.AddMvc();
            /*включение поддержки  аутентификации  на  основе  Cookies*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o => o.LoginPath = new PathString("/Home/Login"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            /*включение поддержки  аутентификации  на  основе  Cookies*/
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                   name: "OnlyAction",
                   template: "{action}",
                   defaults: new { controller = "Home", action = "Index" });


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
