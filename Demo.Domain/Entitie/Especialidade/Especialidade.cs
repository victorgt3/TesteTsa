using System;
using Demo.Domain.Core.Models;

namespace Demo.Domain.Entitie.Especialidade
{
    public class Especialidade : Entity<Especialidade>
    {
        public Guid MedicoId { get;  set; }
        public string Descricao { get; set; }
        public virtual Medico.Medico Medico { get; set; }
        public void AtribuirMedico(Medico.Medico medico)
        {
            Medico = medico;
        }
        protected Especialidade() { }
        public Especialidade(Guid medicoId, string descricao)
        {
            Id = Guid.NewGuid();
            MedicoId = medicoId;
            Descricao = descricao;
        }
        public override bool EhValido()
        {
            return true;
        }
    }
}
