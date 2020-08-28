using FluentValidation;
using System;
using Demo.Domain.Core.Models;
using Demo.Domain.Validator;

namespace Demo.Domain.Entitie.Medico
{
    public class Medico : Entity<Medico>
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Crm { get; private set; }
        public virtual Especialidade.Especialidade Especialidade { get; set; }
        public void AtribuirEspecialidade(Especialidade.Especialidade especialidade)
        {
            Especialidade = especialidade;
        }
        protected Medico() { }
        public Medico(Guid id, string nome, string cpf, string crm, string descricao)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Nome = nome;
            CPF = cpf;
            Crm = crm;
            Especialidade = new Especialidade.Especialidade(Id, descricao);
        }
        public override bool EhValido()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O nome precisa ser fornecida")
               .Length(2, 255).WithMessage("O nome precisa ter entre 2 a 255 caracteres");

            RuleFor(c => c.Crm)
              .NotEmpty().WithMessage("O crm precisa ser fornecida")
              .Length(2, 50).WithMessage("O crm precisa ter entre 2 a 50 caracteres");

            RuleFor(s => s.CPF)
              .NotEmpty().WithMessage("O campo CPF é requerido.")
              .Length(11).WithMessage("O campo CPF deve ser igual a 11 caracteres.")
              .Must(d => ValidaDores.IsCpf(d.ToString())).WithMessage("CPF invalido.");

            RuleForEach(c => c.Especialidade.Descricao)
                .NotEmpty()
                .WithMessage("Uma especialidade é obrigatoria.");


            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
