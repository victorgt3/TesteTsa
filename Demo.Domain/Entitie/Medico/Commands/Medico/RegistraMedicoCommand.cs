using System;
using System.Collections.Generic;
using Demo.Domain.Core.Commands;

namespace Demo.Domain.Entitie.Medico.Commands.Medico
{
    public class RegistraMedicoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Crm { get; set; }
        public List<string> Especialidades { get; set; }
        public RegistraMedicoCommand(Guid id, string nome, string cpf, string crm)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Crm = crm;
            Especialidades = new List<string>();
        }
    }
}
