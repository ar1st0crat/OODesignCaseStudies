using AirportAppCqrs.Domain;
using AirportAppCqrs.ViewModel;
using MediatR;
using StructureMap;
using System.Windows;

namespace AirportAppCqrs
{
    public partial class App : System.Windows.Application
    {
        void AppInitialize(object sender, StartupEventArgs e)
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<Flight>();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<Mediator>();
            });

            var mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(container.TryGetInstance<IMediator>())
            };

            mainWindow.Show();
        }
    }
}
