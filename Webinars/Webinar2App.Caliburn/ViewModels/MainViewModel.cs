using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Webinar1App.Entities;
using Webinar1App.Services;

namespace Webinar2App.Wpf.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly IDriverService _driverService = new DriverService();
        private readonly IMapper _mapper;

        private ObservableCollection<DriverViewModel> _drivers;
        public ObservableCollection<DriverViewModel> Drivers
        {
            get => _drivers;
            set
            { 
                _drivers = value;
                OnPropertyChanged(nameof(Drivers));
            }
        }

        public ICommand AddDriverCommand { get; }
        public ICommand RemoveDriverCommand { get; }

        public MainViewModel()
        {
            _mapper = InitMappings();

            AddDriverCommand = new RelayCommand(AddDriver);
            RemoveDriverCommand = new RelayCommand(RemoveDriver);

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
            });

            return config.CreateMapper();
        }

        private void FillDriversDataGrid()
        {
            Drivers = _mapper.Map<ObservableCollection<DriverViewModel>>(_driverService.GetDrivers());

            // без AutoMapper-а писали бы вручную что-то вроде этого:

            //Drivers = _driverService.GetDrivers()
            //                        .Select(d => new DriverViewModel
            //                        {
            //                            FirstName = d.FirstName,
            //                            LastName = d.LastName,
            //                            ExperienceYears = d.ExperienceYears,
            //                            CarModel = d.Car.Model,
            //                            CarMake = d.Car.Make,
            //                            CarNo = d.Car.No,
            //                            CarColor = d.Car.Color.ToString()
            //                        })
            //                        .ToList();
        }

        private void AddDriver()
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
        }
    }
}
