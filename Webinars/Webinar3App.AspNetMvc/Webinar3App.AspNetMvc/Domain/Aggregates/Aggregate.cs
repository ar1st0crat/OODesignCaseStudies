using System.Collections.Generic;
using Webinar3App.AspNetMvc.Domain.Events;

namespace Webinar3App.AspNetMvc.Domain.Aggregates
{
    public class Aggregate
    {
        public int Id { get; set; }

        /// <summary>
        /// Агрегат может также "собирать" события, связанные с изменением своего состояния
        /// </summary>
        public List<Event> Events { get; set; }
    }
}
