using System.Collections.Generic;

namespace Demo.Domain.Entitie.Medico
{
    public class Response
    {
        public Response()
        {
            Medico = new List<Medico>();
            Especialidade = new List<Especialidade.Especialidade>();
        }
        public List<Medico> Medico { get; set; }
        public List<Especialidade.Especialidade> Especialidade { get; set; }
    }
}
