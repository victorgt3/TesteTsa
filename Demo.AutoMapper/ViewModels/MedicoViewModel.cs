using System;

namespace Demo.AutoMapper.ViewModels
{
    public class MedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Crm { get; set; }
        public EspecialidadeViewModel Especialidade { get; set; }
    }
}
