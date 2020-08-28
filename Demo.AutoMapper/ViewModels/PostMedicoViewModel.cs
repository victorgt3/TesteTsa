using System;
using System.Collections.Generic;

namespace Demo.AutoMapper.ViewModels
{
    public class PostMedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Crm { get; set; }
        public List<string> Especialidades { get; set; }
        public PostMedicoViewModel()
        {
            Especialidades = new List<string>();
        }
    }
}
