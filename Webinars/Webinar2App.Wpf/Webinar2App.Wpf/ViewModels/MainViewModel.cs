using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Serilog;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Webinar1App.Entities;
using Webinar1App.Services;
using Webinar2App.Wpf.Services.Dialogs;
using Webinar2App.Wpf.Util;

namespace Webinar2App.Wpf.ViewModels
{
    // Если бы не использовали Fody, то писали бы так:
    //
    //class MainViewModel : ViewModelBase
    //{
    //    private ObservableCollection<DriverViewModel> _drivers;
    //    public ObservableCollection<DriverViewModel> Drivers
    //    {
    //        get => _drivers;
    //        set
    //        {
    //            _drivers = value;
    //            OnPropertyChanged(nameof(Drivers));
    //        }
    //    }
    //}


    class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDriverService _driverService = new DriverService();
        private readonly IMapper _mapper;

        private readonly IDialogService _dialogService = new DialogService();

        public ObservableCollection<DriverViewModel> Drivers { get; set; }
        
        public int RandomCount { get; set; }
        
        // лучше использовать здесь ValueConverter:
        public Visibility RandomVisibility { get; set; } = Visibility.Hidden;


        public ICommand AddDriverCommand { get; }
        public ICommand AddRandomCommand { get; }
        public ICommand RemoveDriverCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            AddDriverCommand = new RelayCommand(AddDriver);
            AddRandomCommand = new RelayCommand(AddRandom);
            RemoveDriverCommand = new RelayCommand(RemoveDriver);

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
            var viewModel = _mapper.Map<DriverWindowViewModel>(new Driver());
            var res = _dialogService.OpenDialog(viewModel);

            if (res != true) return;

            var driver = _mapper.Map<Driver>(viewModel);

            _driverService.AddDriver(driver);

            FillDriversDataGrid();

            Log.Information("Добавлен водитель: {@driver}", driver);
        }

        private void AddRandom()
        {
            _driverService.AddDriver(null);

            FillDriversDataGrid();

            Log.Information("Сгенерирован водитель: {@driver}", _driverService.GetDrivers().Last());


            // это просто для UI:

            if (RandomCount == 0)
            {
                RandomVisibility = Visibility.Visible;
                Log.Debug("Появился бейдж");
            }

            RandomCount++;
        }

        /// <summary>
        /// Для демонстрации ObservableCollection
        /// (здесь водитель не удаляется в самом источнике данных)
        /// </summary>
        private void RemoveDriver()
        {
            if (Drivers.Count > 0)
            {
                Drivers.RemoveAt(0);
            }
        }
    }
}
