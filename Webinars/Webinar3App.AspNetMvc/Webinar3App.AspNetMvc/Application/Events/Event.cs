using MediatR;
using System;

namespace Webinar3App.AspNetMvc.Application.Events
{
    public abstract class Event : INotification
    {
        public virtual Guid Id { get; } = Guid.NewGuid();

        public virtual DateTime CreatedUtc { get; } = DateTime.UtcNow;
    }
}
