using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Interfaces;



namespace Demo.Domain.Entitie.Medico.Repository
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Response> GetAll();

        Task<Response> GetById(Guid id);

        Task<IEnumerable<Domain.Entitie.Especialidade.Especialidade>> GetByEspecialidade(string especialidade);
    }
}
