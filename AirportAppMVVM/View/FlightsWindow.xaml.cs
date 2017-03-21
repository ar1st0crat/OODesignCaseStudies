using AirportAppMVVM.ViewModel;
using System.Windows;

namespace AirportAppMVVM.View
{
    public partial class FlightsWindow : Window
    {
        public FlightsWindow()
        {
            InitializeComponent();
            DataContext = new FlightsViewModel();
        }

        // обработчики нажатий на кнопки можно тоже убрать
        // (все можно реализовать в XAML-коде с применением паттерна Command)

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as FlightsViewModel;
            viewModel.LoadFlights();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as FlightsViewModel;
            viewModel.LoadFlightsByDepartureCity();
        }
    }
}
