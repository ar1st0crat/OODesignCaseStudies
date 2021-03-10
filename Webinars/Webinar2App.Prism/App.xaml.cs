using Prism.Ioc;
using Prism.DryIoc;
using System.Windows;
using Webinar2App.Prism.Views;
using Webinar2App.Prism.ViewModels;

namespace Webinar2App.Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DriverWindow, DriverWindowViewModel>();
        }
    }
}
