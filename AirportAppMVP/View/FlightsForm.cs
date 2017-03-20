using System;
using System.Windows.Forms;

namespace AirportAppMVP.View
{
    public partial class FlightsForm : Form
    {
        public DataGridView FlightsList
        {
            get { return dataGridFlights; }
            set { dataGridFlights = value; }
        }

        public string DepartureCity
        {
            get { return textBoxDepartureCity.Text; }
            set { textBoxDepartureCity.Text = value; }
        }

        public event EventHandler FlightsQueried;
        public event EventHandler FlightsByDepartureCityQueried;

        public FlightsForm()
        {
            InitializeComponent();
        }

        // далее всё, что происходит в представлении (вьюхе), -
        // это просто поднятие событий при действиях с контролами
        //                           |
        //                           V

        private void FlightsForm_Load(object sender, EventArgs e)
        {
            var ev = FlightsQueried;
            if (ev != null)
                FlightsQueried(sender, e);
        }

        private void buttonLoadFlights_Click(object sender, EventArgs e)
        {
            var ev = FlightsQueried;
            if (ev != null)
                FlightsQueried(sender, e);
        }

        private void buttonFlightsByDepartureCity_Click(object sender, EventArgs e)
        {
            var ev = FlightsByDepartureCityQueried;
            if (ev != null)
               FlightsByDepartureCityQueried(sender, e);
        }
    }
}
