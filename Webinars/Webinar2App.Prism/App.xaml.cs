using Prism.Ioc;
using Prism.DryIoc;
using System.Windows;
using Webinar2AppPrism.Views;
using Webinar2AppPrism.ViewModels;

namespace Webinar2AppPrism
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
