using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Caliburn.Micro;
using Webinar1App.Entities;
using Webinar1App.Services;

namespace Webinar2App.Caliburn.ViewModels
{
    // Можно наследоваться еще от Screen и Conductor<>...

    class MainWindowViewModel : PropertyChangedBase
    {
        private readonly IDriverService _driverService = new DriverService();
        private readonly IMapper _mapper;
        
        private readonly IWindowManager _windowManager = new WindowManager();

        private BindableCollection<DriverViewModel> _drivers;
        public BindableCollection<DriverViewModel> Drivers
        {
            get => _drivers;
            set
            {
                _drivers = value;
                NotifyOfPropertyChange(() => Drivers);
            }
        }


        public MainWindowViewModel()
        {
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
            Drivers = _mapper.Map<BindableCollection<DriverViewModel>>(_driverService.GetDrivers());
        }

        public void AddRandom()
        {
            _driverService.AddDriver(null);

            FillDriversDataGrid();
        }

        public void AddDriver()
        {
            var viewModel = _mapper.Map<DriverWindowViewModel>(new Driver());
            
            var result = _windowManager.ShowDialog(viewModel);

            if (result != true) return;

            var driver = _mapper.Map<Driver>(viewModel);

            _driverService.AddDriver(driver);

            FillDriversDataGrid();
        }

        /// <summary>
        /// Для демонстрации ObservableCollection
        /// (здесь водитель не удаляется в самом источнике данных)
        /// </summary>
        public void RemoveDriver()
        {
            Drivers.RemoveAt(0);
            NotifyOfPropertyChange(() => CanRemoveDriver);
        }

        public bool CanRemoveDriver => Drivers.Count > 0;
    }
}
