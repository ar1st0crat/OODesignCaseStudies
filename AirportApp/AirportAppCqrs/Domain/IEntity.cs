using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportAppCqrs.Domain
{
    public interface IEntity
    {
        long Id { get; set; }
    }
}
