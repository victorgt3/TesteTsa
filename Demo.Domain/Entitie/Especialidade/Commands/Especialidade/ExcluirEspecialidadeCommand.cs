using System;
using Demo.Domain.Core.Commands;

namespace Demo.Domain.Entitie.Especialidade.Commands.Especialidade
{
    public class ExcluirEspecialidadeCommand : Command
    {
        public Guid Id { get; set; }

        public ExcluirEspecialidadeCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }

}
