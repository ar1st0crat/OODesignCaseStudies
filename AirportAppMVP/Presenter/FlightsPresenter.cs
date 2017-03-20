using AirportAppMVP.Model;
using AirportAppMVP.View;

namespace AirportAppMVP.Presenter
{
    public class FlightsPresenter
    {
        FlightsModel _model = new FlightsModel();
        FlightsForm _view;

        public FlightsPresenter(FlightsForm view)
        { 
            _view = view;
            _view.FlightsQueried += UpdateFlightsView;
            _view.FlightsByDepartureCityQueried += UpdateFilteredFlightsView;
        }

        private void ShowFlights()
        {
            var flights = _model.Flights;
            var flightsView = _view.FlightsList;

            flightsView.Rows.Clear();
            flightsView.ColumnCount = 3;
            flightsView.RowCount = flights.Count;

            for (int i = 0; i < flights.Count; i++)
            {
                flightsView.Rows[i].Cells[0].Value = flights[i].Code;
                flightsView.Rows[i].Cells[1].Value = flights[i].DepartureCity;
                flightsView.Rows[i].Cells[2].Value = flights[i].ArrivalCity;
            }
        }

        private void UpdateFlightsView(object sender, System.EventArgs e)
        {
            _model.Load();
            ShowFlights();
        }

        public void UpdateFilteredFlightsView(object sender, System.EventArgs e)
        {
            if (_view.DepartureCity != "")
            {
                _model.LoadByDepartureCity(_view.DepartureCity);
                ShowFlights();
            }
        }
    }
}
