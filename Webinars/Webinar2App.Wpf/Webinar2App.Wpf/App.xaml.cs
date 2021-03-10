using Serilog;
using System.Windows;
using Webinar2App.Wpf.ViewModels;
using Webinar2App.Wpf.Views;

namespace Webinar2App.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppInit(object sender, StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/taxiapp.log", rollingInterval: RollingInterval.Month)
                .CreateLogger();

            
            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };

            mainWindow.ShowDialog();


            Log.CloseAndFlush();
        }
    }
}
