using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Data;
using Webinar3App.AspNetMvc.Domain.Aggregates;
using Webinar3App.AspNetMvc.Domain.Events;

namespace Webinar3App.AspNetMvc.Application.EventHandlers
{
    public class DriverCreatedEventHandler : INotificationHandler<DriverCreatedEvent>
    {
        private readonly ReadModelDataContext _readModel;
        private readonly IMapper _mapper;

        public DriverCreatedEventHandler(ReadModelDataContext db, IMapper mapper)
        {
            _readModel = db;
            _mapper = mapper;
        }

        public Task Handle(DriverCreatedEvent @event, CancellationToken cancellationToken)
        {
            //_eventStore.Add(@event);      // это намек на EventSourcing в другом проекте

            var driver = _mapper.Map<Driver>(@event);

            _readModel.AddDriver(driver);

            return Task.CompletedTask; 
        }
    }
}
