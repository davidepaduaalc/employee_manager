using employee_manager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace employee_manager
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config){
            _config = config;

        }
        // Este método é usado para configurar os serviços do aplicativo.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure os serviços necessários aqui.
            
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();
           
        }

        // Este método é usado para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            // Configure como as solicitações HTTP devem ser tratadas aqui.
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseRouting();

            app.UseEndpoints(endpoints =>{
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );  
            });

            app.UseStaticFiles();
            app.Run(async (context) => 
            {
                await context.Response.WriteAsync($"Hello Worlds!!");
            });
            
        }
    }
}