using System;
using Demo.Domain.Core.Commands;

namespace Demo.Domain.Entitie.Medico.Commands.Medico
{
    public class ExcluirMedicoCommand : Command
    {
        public Guid Id { get; set; }

        public ExcluirMedicoCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
