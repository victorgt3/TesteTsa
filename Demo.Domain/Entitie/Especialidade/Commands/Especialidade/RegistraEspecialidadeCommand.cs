using System;
using Demo.Domain.Core.Commands;

namespace Demo.Domain.Entitie.Especialidade.Commands.Especialidade
{
    public class RegistraEspecialidadeCommand : Command
    {
        public Guid MedicoId { get; set; }
        public string Descricao { get; set; }
        public RegistraEspecialidadeCommand(Guid medicoId, string descricao)
        {
            MedicoId = medicoId;
            Descricao = descricao;
        }
    }
}
