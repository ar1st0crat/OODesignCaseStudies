using AirportAppMVC.Model;

namespace AirportAppMVC.Controller
{
    public class FlightsController
    {
        FlightsModel _model;

        // C# 6.0 style:
        // public void SetModel(FlightsModel model) => _model = model;

        public void SetModel(FlightsModel model)
        {
            _model = model;
        }
        
        public void LoadAllFlights()
        {
            // отправляем запрос модели;
            // в данном случае - без всякой доп. логики
            _model.Load();
        }

        public void LoadFlightsByDepartureCity(string city)
        {
            if (city != "")     // пример доп. логики в контроллере
            {
                _model.LoadByDepartureCity(city);
            }
        }
    }
}
