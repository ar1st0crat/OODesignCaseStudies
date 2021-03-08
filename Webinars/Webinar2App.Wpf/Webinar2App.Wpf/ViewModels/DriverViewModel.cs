using System.ComponentModel;

namespace Webinar2App.Wpf.ViewModels
{
    // Без Fody:
    // class DriverViewModel : ViewModelBase
    // ...


    // Будет работать Fody.PropertyChanged:

    class DriverViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceYears { get; set; }

        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNo { get; set; }
        public string CarColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
