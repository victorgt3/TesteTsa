using System;
using Demo.Domain.Core.Events;

namespace Demo.Domain.Entitie.Especialidade.Events.Especialidade
{
    public class EspecialidadeExcluidoEvent : Event
    {
        public Guid Id { get; set; }

        public EspecialidadeExcluidoEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
