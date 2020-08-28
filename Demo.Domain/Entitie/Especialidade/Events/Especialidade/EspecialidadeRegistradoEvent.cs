using System;
using Demo.Domain.Core.Events;

namespace Demo.Domain.Entitie.Especialidade.Events.Especialidade
{
    public class EspecialidadeRegistradoEvent : Event
    {
        public Guid MedicoId { get; set; }
        public string Descricao { get; set; }
        public EspecialidadeRegistradoEvent(Guid medicoId, string descricao)
        {
            MedicoId = medicoId;
            Descricao = descricao;
        }
    }
}
