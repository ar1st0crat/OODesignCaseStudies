using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Domain.Driver;
using Webinar3App.EventSourcing.ReadModels;

namespace Webinar3App.EventSourcing.Application.Interfaces
{
    public interface IDriverQueryService
    {
        Task<IEnumerable<DriverReadModel>> GetActiveDrivers(CancellationToken token);

        Task<DriverReadModel> GetDriverById(DriverId id, CancellationToken token);
    }
}
