using AutoMapper;
using Webinar3App.AspNetMvc.Application.Commands;
using Webinar3App.AspNetMvc.Application.Dto;
using Webinar3App.AspNetMvc.Domain.Aggregates;
using Webinar3App.AspNetMvc.Domain.Events;

namespace Webinar3App.AspNetMvc.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, AddDriverCommand.Command>().ReverseMap();

            CreateMap<Driver, DriverCreatedEvent>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.DriverId, opt => opt.MapFrom(f => f.Id))
                .ForMember(m => m.CarNo, opt => opt.MapFrom(f => f.Car.No))
                .ForMember(m => m.CarModel, opt => opt.MapFrom(f => f.Car.Model))
                .ForMember(m => m.CarMake, opt => opt.MapFrom(f => f.Car.Make))
                .ForMember(m => m.CarColor, opt => opt.MapFrom(f => f.Car.Color))
                .ReverseMap();

            CreateMap<Driver, DriverDto>()
                .ForMember(m => m.CarNo, opt => opt.MapFrom(f => f.Car.No))
                .ForMember(m => m.CarModel, opt => opt.MapFrom(f => f.Car.Model))
                .ForMember(m => m.CarMake, opt => opt.MapFrom(f => f.Car.Make))
                .ForMember(m => m.CarColor, opt => opt.MapFrom(f => f.Car.Color))
                .ReverseMap();

            CreateMap<DriverCreatedEvent, DriverDto>().ReverseMap();
        }
    }
}
