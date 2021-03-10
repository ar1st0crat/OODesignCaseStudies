using Caliburn.Micro;
using System.Windows;
using Webinar2App.Caliburn.ViewModels;

namespace Webinar2App.Caliburn
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}
