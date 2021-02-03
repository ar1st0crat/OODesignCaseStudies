using AirportAppRx.Service;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace AirportAppRx.ViewModel
{
    public class MainWindowViewModel : ReactiveObject
    {
        /// <summary>
        /// Это нужно прокинуть зависимостью в конструктор и использовать DI,
        /// но сейчас не об этом и прошьем флайт сервис здесь явно:
        /// </summary>
        private readonly FlightService _flightService = new FlightService();

        private string _flightCode;
        public string FlightCode
        {
            get => _flightCode;
            set => this.RaiseAndSetIfChanged(ref _flightCode, value);
        }

        private ReadOnlyObservableCollection<FlightViewModel> _flights;
        public ReadOnlyObservableCollection<FlightViewModel> Flights
        {
            get => _flights;
            set => this.RaiseAndSetIfChanged(ref _flights, value);
        }

        private readonly ObservableAsPropertyHelper<string> _currentFlight;
        public string CurrentFlight => _currentFlight?.Value;

        private readonly ObservableAsPropertyHelper<string> _flightCount;
        public string FlightCount => _flightCount?.Value;

        public ReactiveCommand<Unit, Unit> LoadFlightsCommand { get; }
        public ReactiveCommand<Unit, Unit> AddRandomFlightCommand { get; }


        /// <summary>
        /// По сути, все самое главное происходит в конструкторе:
        /// </summary>
        public MainWindowViewModel()
        {
            // Декларативный подход:

            // говорим, что фильтр рейсов будет реактивно обновляться при обновлении свойства FlightCode

            var flightFilter = this.WhenAnyValue(x => x.FlightCode).Select(FlightCodeFilter);

            // "реактивно" связываем нашу observable-коллекцию Flight с источником данных из _flightService

            _flightService
                .Connect()                                                              // берем все рейсы (объекты Flight)
                .Transform(f => f.ToViewModel())                                        // преобразуем каждый Flight в FlightViewModel
                .Filter(flightFilter)                                                   // применяем фильтр (по умолчанию все пропускаем)
                .Sort(SortExpressionComparer<FlightViewModel>.Ascending(x => x.Code))   // сортируем по коду рейса в порядке возрастания
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _flights)
                .DisposeMany()
                .Subscribe();

            // говорим, что текст с кол-вом рейсов будет реактивно обновляться при обновлении Flights

            _flightCount = _flights.ToObservableChangeSet()
                                   .CountChanged()
                                   .Select(x => $"{_flights.Count()} flights!")
                                   .ToProperty(this, x => x.FlightCount);

            // говорим, что текущий рейс (который отображается вверху окна)
            // реактивно будет обновляться по таймеру:

            _currentFlight = Observable.Interval(TimeSpan.FromSeconds(1.5))
                                       .Select(_ => SwitchCurrentFlight())
                                       .ObserveOn(RxApp.MainThreadScheduler)
                                       .ToProperty(this, x => x.CurrentFlight);

            // примеры реактивных команд. Тоже все декларативно:

            LoadFlightsCommand = ReactiveCommand.Create(
                () => { FlightCode = ""; }
            );

            AddRandomFlightCommand = ReactiveCommand.Create(
                () => { _flightService.AddRandomFlight(); }
            );


            // Можно еще добавить условие выполнимости команды, например:

            //var canAddRandomFlight = this.WhenAnyValue(x => x.FlightCode).Select(x => string.IsNullOrEmpty(x));

            //AddRandomFlightCommand = ReactiveCommand.Create(
            //    () => { _flightService.AddRandomFlight(); },
            //    canAddRandomFlight
            //);
        }


        // далее - уже просто отдельные детали функциональности, разбросанные по функциям:

        /// <summary>
        /// Возвращает новую функцию-фильтр рейсов
        /// (фильтр обновляется, когда обновляется flightCode в текстбоксе)
        /// </summary>
        /// <param name="flightCode"></param>
        /// <returns></returns>
        private Func<FlightViewModel, bool> FlightCodeFilter(string flightCode)
        {
            return x => string.IsNullOrEmpty(flightCode) || x.Code.StartsWith(flightCode);
        }

        /// <summary>
        /// Рандомно поменять текущий рейс (который отображается вверху окна)
        /// </summary>
        private string SwitchCurrentFlight()
        {
            if (!_flights.Any()) return string.Empty;

            var flight = _flights.ElementAt(_randomizer.Next(_flights.Count));

            return $"{flight.Code}  / {flight.DepartureCity} -> {flight.ArrivalCity} /";
        }

        private readonly Random _randomizer = new Random();
    }
}
