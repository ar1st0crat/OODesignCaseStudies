
namespace Webinar2App.Wpf.Services.Dialogs
{
    public class DialogService : IDialogService
    {
        public bool? OpenDialog(IDialogViewModel dialogViewModel)
        {
            var window = DialogViewLocator.View(dialogViewModel);
            if (window == null) return false;

            window.DataContext = dialogViewModel;
            window.ShowDialog();

            return dialogViewModel.DialogResult;
        }
    }
}
