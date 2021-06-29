using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Application.Events;
using Webinar3App.AspNetMvc.Data;

namespace Webinar3App.AspNetMvc.Application.Commands
{
    /// <summary>
    /// Structure of queries/commands/events is taken from:
    /// 
    /// https://github.com/madslundt/NetCoreMicroservicesSample
    /// 
    /// </summary>
    public class RemoveDriverCommand
    {
        /// <summary>
        /// Command parameters
        /// </summary>
        public class Command : IRequest<Result>
        {
            public int Id { get; set; }
        }
        
        /// <summary>
        /// Quote from [https://vladikk.com/2017/03/20/tackling-complexity-in-cqrs/] :
        /// 
        /// Without violating any CQRS principles, a command can safely return the following data:
        ///     - Execution result: success or failure;
        ///     - Error messages or validation errors, in case of a failure;
        ///     - The aggregate’s new version number, in case of success;
        /// 
        /// </summary>
        public class Result
        {
            public string Error { get; set; }
        }

        /// <summary>
        /// Validators will be injected into MediatR pipeline (and then into ASP.NET)
        /// </summary>
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(cmd => cmd.Id).GreaterThan(0);
            }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly DataContext _db;
            private readonly IMediator _mediator;

            public Handler(DataContext db, IMediator mediator)
            {
                _db = db;
                _mediator = mediator;
            }

            /// <summary>
            /// https://enterprisecraftsmanship.com/posts/validate-commands-cqrs/
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public Task<Result> Handle(Command command, CancellationToken cancellationToken)
            {
                var driver = _db.Drivers.FirstOrDefault(d => d.Id == command.Id);

                string error = null;

                if (driver == null)
                {
                    error = "Driver not found";
                }
                else
                {
                    _db.Drivers.Remove(driver);
                    _db.SaveChanges();

                    // Or we could do the SOFT delete (like in EventSourcing):
                    // 
                    // We'd still have the data in our event store.
                    // We'd publish a 'deleted' event which would remove/mark the data as deleted in read model.
                    // 
                }

                var result = new Result
                {
                    Error = error
                };

                if (error == null)
                {
                    var @event = new DriverRemovedEvent()
                    {
                        DriverId = driver.Id
                    };

                    _mediator.Publish(@event);
                }

                return Task.FromResult(result);
            }
        }
    }
}
