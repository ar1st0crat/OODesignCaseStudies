using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using EventFlow.EventStores.Files;
using Webinar3App.EventSourcing.ReadModels;
using Webinar3App.EventSourcing.Application.Services;
using Webinar3App.EventSourcing.Application.Interfaces;
using Webinar3App.EventSourcing.Infrastructure;
using Webinar3App.EventSourcing.Domain.Interfaces;
using FluentValidation.AspNetCore;

namespace Webinar3App.EventSourcing
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

            services.AddFluentValidation(cfg => 
            { 
                cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddEventFlow(ef =>
            {
                ef.AddAspNetCore()
                  .AddDefaults(typeof(Startup).Assembly)
                  .UseConsoleLog()
                  .UseInMemoryReadStoreFor<DriverReadModel>()
                  .UseInMemorySnapshotStore()
                  .UseFilesEventStore(FilesEventStoreConfiguration.Create("d:\\ES"))
                  .RegisterServices(s => 
                  {
                      s.Register<IDriverQueryService, DriverQueryService>();
                      s.Register<IEntityGeneratorService, EntityGeneratorService>();
                  });

                //.AddEvents(typeof(DriverCreatedEvent))
                //.AddCommands(typeof(AddDriverCommand))
                //.AddCommandHandlers(typeof(AddDriverCommandHandler))
                //.PublishToRabbitMq(RabbitMqConfiguration.With(new Uri(env.RabbitMqConnection)))
            });
        }

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
