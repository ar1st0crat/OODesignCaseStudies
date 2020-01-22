using AirportAppCqrs.Application.Commands;
using AirportAppCqrs.Application.Queries;
using MediatR;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace AirportAppCqrs.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly IMediator _mediator;

        private ObservableCollection<FlightViewModel> _flights;
        public ObservableCollection<FlightViewModel> Flights
        {
            get { return _flights; }
            set
            {
                _flights = value;
                OnPropertyChanged("Flights");
            }
        }

        public string FlightCode { get; set; }


        public MainWindowViewModel(IMediator mediator)
        {
            _mediator = mediator;

            LoadFlights();
        }

        public async Task LoadFlights()
        {
            var query = new GetFlightsQuery();

            var flights = await _mediator.Send(query);

            Flights = new ObservableCollection<FlightViewModel>(flights);
        }

        public async Task LoadFlightByCode()
        {
            var query = new GetFlightByCodeQuery() { Code = FlightCode };

            var flight = await _mediator.Send(query);

            Flights = new ObservableCollection<FlightViewModel>();

            if (flight != null)
            {
                Flights.Add(flight);
            }
        }

        public async Task AddRandomFlight()
        {
            var command = new AddFlightCommand
            {
                Code = Path.GetRandomFileName().Replace(".", "").Substring(0, 3),
                CompanyId = 1,
                DepartureCity = "Random",
                ArrivalCity = "Random"
            };

            await _mediator.Send(command);

            await LoadFlights();
        }
    }
}
