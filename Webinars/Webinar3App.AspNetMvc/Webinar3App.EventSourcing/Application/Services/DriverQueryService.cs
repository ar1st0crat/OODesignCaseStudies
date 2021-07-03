using EventFlow.Queries;
using EventFlow.ReadStores.InMemory.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.EventSourcing.Application.Interfaces;
using Webinar3App.EventSourcing.Domain.Driver;
using Webinar3App.EventSourcing.ReadModels;

namespace Webinar3App.EventSourcing.Application.Services
{
    public class DriverQueryService : IDriverQueryService
    {
        private readonly IQueryProcessor _queryProcessor;

        public DriverQueryService(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public async Task<IEnumerable<DriverReadModel>> GetActiveDrivers(CancellationToken token)
        {
            var result = await _queryProcessor.ProcessAsync(new InMemoryQuery<DriverReadModel>(p => !p.IsRemoved), token);

            return result;
        }

        public async Task<DriverReadModel> GetDriverById(DriverId id, CancellationToken token)
        {
            var result = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<DriverReadModel>(id), token);

            return result;
        }

    }
}
