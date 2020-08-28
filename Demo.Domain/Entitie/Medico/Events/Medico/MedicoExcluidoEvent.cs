using System;
using Demo.Domain.Core.Events;

namespace Demo.Domain.Entitie.Medico.Events.Medico
{
    public class MedicoExcluidoEvent : Event
    {
        public Guid Id { get; set; }

        public MedicoExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
