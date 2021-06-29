using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Application.Events;
using Webinar3App.AspNetMvc.Data;

namespace Webinar3App.AspNetMvc.Application.EventHandlers
{
    public class DriverRemovedEventHandler : INotificationHandler<DriverRemovedEvent>
    {
        private readonly ReadModelDataContext _readModel;

        public DriverRemovedEventHandler(ReadModelDataContext db)
        {
            _readModel = db;
        }

        public Task Handle(DriverRemovedEvent @event, CancellationToken cancellationToken)
        {
            //_eventStore.Add(@event);      // это намек на EventSourcing в другом проекте

            _readModel.RemoveDriver(@event.DriverId);

            return Task.CompletedTask;
        }
    }
}
