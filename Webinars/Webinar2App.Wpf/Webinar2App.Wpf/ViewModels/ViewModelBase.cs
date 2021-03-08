using System.ComponentModel;

namespace Webinar2App.Wpf.ViewModels
{
    // использовали этот базовый класс по ходу вебинара,
    // но в текущей (конечной) реализации применяется Fody.PropertyChanged:

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
