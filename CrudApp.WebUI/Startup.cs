using CrudApp.WebUI.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrudApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Context burada .NET Core'a tan�t�l�yor
            services.AddDbContext<CrudAppContext>();
            // MVC patterni kullanmak i�in bu servis �a�r�l�yor
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // default isminde URL y�nlendirmesi yapan endpoint
                // pattern isimli parametreye g�re kullan�c� ilk �a�r���mda
                // varsay�lan olarak HomeController i�indeki Index metoduna y�nlenir
                // 3. bir (id ye denk gelen de�er) de�er olsada olur, olmasada olur
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}"
                );
            });
        }
    }
}
