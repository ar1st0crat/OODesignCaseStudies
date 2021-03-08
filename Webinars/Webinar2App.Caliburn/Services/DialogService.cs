using Webinar2App.Wpf.ViewModels;

namespace Webinar2App.Wpf.Services
{
    public class DialogService : IDialogService
    {
        public void ShowDialogModal(DialogViewModelBase vm)
        {
            DialogView v = new DialogView();
            v.Owner = vm.Owner;
            v.DataContext = vm;
            v.ShowDialog();
            v.Owner = null;
        }
    }
}
