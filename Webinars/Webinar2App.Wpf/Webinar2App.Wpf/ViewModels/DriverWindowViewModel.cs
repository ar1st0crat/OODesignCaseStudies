using System.ComponentModel;
using System.Windows.Input;
using Webinar2App.Wpf.Services.Dialogs;
using Webinar2App.Wpf.Util;

namespace Webinar2App.Wpf.ViewModels
{
    // Будет работать Fody.PropertyChanged:

    class DriverWindowViewModel : IDialogViewModel, INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }
        public string CarColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool? DialogResult { get; set; }

        public ICommand OkCommand { get; }

        public DriverWindowViewModel()
        {
            OkCommand = new RelayCommand(() => DialogResult = true);
        }
    }
}
