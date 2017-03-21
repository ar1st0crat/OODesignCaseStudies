using AirportAppMVVM.Model;
using AirportAppMVVM.Model.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AirportAppMVVM.ViewModel
{
    public class FlightsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Flight> _flights;
        public ObservableCollection<Flight> Flights
        {
            get { return _flights; }
            set
            {
                _flights = value;
                OnPropertyChanged("Flights");
            }
        }

        private Flight _selectedFlight;
        public Flight SelectedFlight
        {
            get { return _selectedFlight; }
            set
            {
                _selectedFlight = value;
                OnPropertyChanged("SelectedFlight");
            }
        }

        private FlightsModel _model = new FlightsModel();

        public FlightsViewModel()
        {
            _model.Load();
            Flights = new ObservableCollection<Flight>(_model.Flights);
        }

        public void LoadFlights()
        {
            _model.Load();
            Flights = new ObservableCollection<Flight>(_model.Flights);
        }

        public void LoadFlightsByDepartureCity()
        {
            if (SelectedFlight == null || SelectedFlight.DepartureCity == "")
            {
                return;
            }

            _model.LoadByDepartureCity(SelectedFlight.DepartureCity);
            Flights = new ObservableCollection<Flight>(_model.Flights);
        }

        #region INPC-related code

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
