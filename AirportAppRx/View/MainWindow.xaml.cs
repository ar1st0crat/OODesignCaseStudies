using AirportAppRx.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace AirportAppRx.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            this.WhenActivated(disposables => {

                this.BindCommand(ViewModel, vm => vm.LoadFlightsCommand, v => v.allFlightsButton)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, vm => vm.AddRandomFlightCommand, v => v.addRandomFlightButton)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.Flights, v => v.flightsListBox.ItemsSource)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.FlightCount, v => v.flightCountTextBlock.Text)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.CurrentFlight, v => v.currentFlightText.Text)
                    .DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.FlightCode, v => v.flightCodeTextBox.Text);
            });
        }
    }
}
