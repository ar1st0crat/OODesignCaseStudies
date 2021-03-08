namespace Webinar2App.Wpf.ViewModels
{
    public class DialogViewModelBase
    {
        public Window Owner { get; set; }

        public void CloseDialog(Window view)
        {
            if (view != null)
                view.DialogResult = true;
        }
    }
}
