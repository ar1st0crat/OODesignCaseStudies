using AirportAppMVC.Controller;
using AirportAppMVC.Model;
using System.Windows.Forms;

namespace AirportAppMVC.View
{
    public partial class FlightsForm : Form
    {
        FlightsController _controller = new FlightsController();
        FlightsModel _model = new FlightsModel();

        public FlightsForm(FlightsController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.SetModel(_model);

            // подписываемся на событие модели (когда она загрузит рейсы)
            _model.FlightsLoaded += UpdateFlightsView;
        }

        private void UpdateFlightsView(object sender, System.EventArgs e)
        {
            var flights = _model.Flights;

            dataGridFlights.Rows.Clear();
            dataGridFlights.ColumnCount = 3;
            dataGridFlights.RowCount = flights.Count;

            for (int i = 0; i < flights.Count; i++)
            {
                dataGridFlights.Rows[i].Cells[0].Value = flights[i].Code;
                dataGridFlights.Rows[i].Cells[1].Value = flights[i].DepartureCity;
                dataGridFlights.Rows[i].Cells[2].Value = flights[i].ArrivalCity;
            }
        }

        private void FlightsForm_Load(object sender, System.EventArgs e)
        {
            // отправляем запрос контроллеру;
            // он уже, в свою очередь, отправит запрос модели
            _controller.LoadAllFlights();
        }

        private void buttonLoadFlights_Click(object sender, System.EventArgs e)
        {
            // отправляем запрос контроллеру;
            // он уже, в свою очередь, отправит запрос модели
            _controller.LoadAllFlights();
        }

        private void buttonFlightsByDepartureCity_Click(object sender, System.EventArgs e)
        {
            // отправляем запрос контроллеру;
            // он уже, в свою очередь, отправит запрос модели
            _controller.LoadFlightsByDepartureCity(textBoxDepartureCity.Text);
        }
    }
}
