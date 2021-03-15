using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using Webinar1App.Entities;
using Webinar1App.Services;

namespace Webinar2AppPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDriverService _driverService = new DriverService();
        private readonly IMapper _mapper;

        private readonly IDialogService _dialogService;


        private string _title = "TaxiApp";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<DriverViewModel> _drivers;
        public ObservableCollection<DriverViewModel> Drivers
        {
            get { return _drivers; }
            set { SetProperty(ref _drivers, value); }
        }


        private DelegateCommand _addDriverCommand;
        public DelegateCommand AddDriverCommand => _addDriverCommand ??= new DelegateCommand(AddDriver);

        private DelegateCommand _addRandomCommand;
        public DelegateCommand AddRandomCommand => _addRandomCommand ??= new DelegateCommand(AddRandom);

        private DelegateCommand _removeDriverCommand;
        public DelegateCommand RemoveDriverCommand => _removeDriverCommand ??= new DelegateCommand(RemoveDriver, CanRemoveDriver);


        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _mapper = InitMappings();

            FillDriversDataGrid();
        }

        private IMapper InitMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddCollectionMappers();

                cfg.CreateMap<Driver, DriverViewModel>()
                   .ForMember(m => m.CarNo, opt => opt.MapFrom(f => f.Car.No))
                   .ForMember(m => m.CarModel, opt => opt.MapFrom(f => f.Car.Model))
                   .ForMember(m => m.CarMake, opt => opt.MapFrom(f => f.Car.Make))
                   .ForMember(m => m.CarColor, opt => opt.MapFrom(f => f.Car.Color));

                cfg.CreateMap<Driver, DriverWindowViewModel>()
                   .ForMember(m => m.CarNo, opt => opt.MapFrom(f => f.Car.No))
                   .ForMember(m => m.CarModel, opt => opt.MapFrom(f => f.Car.Model))
                   .ForMember(m => m.CarMake, opt => opt.MapFrom(f => f.Car.Make))
                   .ForMember(m => m.CarColor, opt => opt.MapFrom(f => f.Car.Color))
                   .ReverseMap();
            });

            return config.CreateMapper();
        }

        private void FillDriversDataGrid()
        {
            Drivers = _mapper.Map<ObservableCollection<DriverViewModel>>(_driverService.GetDrivers());
        }

        private void AddDriver()
        {
            _dialogService.ShowDialog("DriverWindow", r =>
            {
                if (r.Result != ButtonResult.OK) return;

                var driverInfo = r.Parameters.GetValue<DriverWindowViewModel>("driver");
                var driver = _mapper.Map<Driver>(driverInfo);

                _driverService.AddDriver(driver);

                FillDriversDataGrid();
            });
        }

        private void AddRandom()
        {
            _driverService.AddDriver(null);

            FillDriversDataGrid();
        }

        /// <summary>
        /// Для демонстрации ObservableCollection
        /// (здесь водитель не удаляется в самом источнике данных)
        /// </summary>
        private void RemoveDriver()
        {
            Drivers.RemoveAt(0);
            RemoveDriverCommand.RaiseCanExecuteChanged();
        }

        private bool CanRemoveDriver() => Drivers.Count > 0;
    }
}
