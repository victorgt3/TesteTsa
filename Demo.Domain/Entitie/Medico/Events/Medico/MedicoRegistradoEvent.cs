using System;
using System.Collections.Generic;
using Demo.Domain.Core.Events;

namespace Demo.Domain.Entitie.Medico.Events.Medico
{
    public class MedicoRegistradoEvent : Event
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Crm { get; set; }
        public List<string> Especialidades { get; set; }
        public MedicoRegistradoEvent(Guid id, string nome, string cpf, string crm, List<string> especialidades)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Crm = crm;
            Especialidades = especialidades;
        }
    }
}
