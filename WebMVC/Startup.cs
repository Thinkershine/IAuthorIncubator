using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.Services;

namespace WebMVC
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository<WritingPath>, InMemoryWritingPathRepository<WritingPath>>();
            services.AddSingleton<IRepository<WritingDayHeader>, InMemoryWritingDayHeaderRepository<WritingDayHeader>>();
            services.AddSingleton<IRepository<WritingDayBody>, InMemoryWritingDayBodyRepository<WritingDayBody>>();
            services.AddSingleton<IWriterPathService, WritingPathService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
