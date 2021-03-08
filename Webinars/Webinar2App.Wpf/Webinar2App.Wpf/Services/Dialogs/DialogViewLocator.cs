using System.Windows;
using Webinar2App.Wpf.ViewModels;
using Webinar2App.Wpf.Views;

namespace Webinar2App.Wpf.Services.Dialogs
{
    public static class DialogViewLocator
    {
        public static Window View(IDialogViewModel viewModel)
        {
            return viewModel switch
            {
                DriverWindowViewModel dw => new DriverWindow(),
                // SomeOtherViewModel s => new SomeOtherWindow(),
                // SomeOtherViewModel s => new SomeOtherWindow(),
                _ => null,
            };
        }
    }
}
