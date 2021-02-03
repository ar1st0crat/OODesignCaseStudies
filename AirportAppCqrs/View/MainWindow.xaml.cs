using AirportAppCqrs.ViewModel;
using System.Windows;

namespace AirportAppCqrs.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // обработчики нажатий на кнопки можно тоже убрать
        // (все можно реализовать в XAML-коде с применением паттерна Command)

        private async void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            await viewModel.LoadFlights();
        }

        private async void Filter_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            await viewModel.LoadFlightByCode();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            await viewModel.AddRandomFlight();
        }
    }
}
