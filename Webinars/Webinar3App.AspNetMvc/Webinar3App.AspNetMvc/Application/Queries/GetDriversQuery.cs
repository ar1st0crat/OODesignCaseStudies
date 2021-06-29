using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Webinar3App.AspNetMvc.Application.Dto;
using Webinar3App.AspNetMvc.Data;

namespace Webinar3App.AspNetMvc.Application.Queries
{
    public partial class GetDriversQuery
    {
        public class Query : IRequest<Result>
        {
            // query parameters
        }

        public class Result
        {
            public List<DriverDto> Drivers { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
            }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly ReadModelDataContext _db;

            public Handler(ReadModelDataContext db)
            {
                _db = db;
            }

            public Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                var result = new Result
                {
                    Drivers = _db.Drivers
                };

                return Task.FromResult(result);
            }
        }
    }
}
