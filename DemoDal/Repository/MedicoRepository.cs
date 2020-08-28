using Demo.Dal.Context;
using Demo.Domain.Entitie.Medico.Repository;
using System;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Entitie.Medico;
using System.Collections.Generic;

namespace Demo.Dal.Repository
{
    public class MedicoRepository : Repository<Domain.Entitie.Medico.Medico>, IMedicoRepository
    {
        public MedicoRepository(BrtContext context) : base(context)
        {
        }

        public async Task<Response> GetAll()
        {
            var response = new Response();

            const string sql = @"select * from Medicos;
                                select * from Especialidades;";
            var results = Db.Database.GetDbConnection().QueryMultipleAsync(sql).Result;
            var listaMedico = results.Read<Domain.Entitie.Medico.Medico>().ToList();
            var listaEspecialidade = results.Read<Domain.Entitie.Especialidade.Especialidade>().ToList();
            
            response.Medico = listaMedico;
            response.Especialidade = listaEspecialidade;

            return response;
        }

        public async Task<Response> GetById(Guid id)
        {
            var response = new Response();

            const string sql = @"select * from Medicos m WHERE m.Id = @UId;
                                select * from Especialidades e
                                WHERE e.MedicoId = @UId;";
            var results = Db.Database.GetDbConnection().QueryMultipleAsync(sql, new { UId = id}).Result;
            var listaMedico = results.Read<Domain.Entitie.Medico.Medico>().ToList();
            var listaEspecialidade = results.Read<Domain.Entitie.Especialidade.Especialidade>().ToList();

            response.Medico = listaMedico;
            response.Especialidade = listaEspecialidade;

            return response;
        }

        public async Task<IEnumerable<Domain.Entitie.Especialidade.Especialidade>> GetByEspecialidade(string especialidade)
        {
            const string sql = @"SELECT * FROM [tdsadb].[dbo].[Especialidades] e
                             LEFT JOIN [tdsadb].[dbo].[Medicos] m ON e.MedicoId = m.Id
                             WHERE e.Descricao = @UEspecialidades";

            var result = await Db.Database.GetDbConnection().QueryAsync<
                Domain.Entitie.Especialidade.Especialidade, 
                Domain.Entitie.Medico.Medico, Domain.Entitie.Especialidade.Especialidade>(sql, 
                (e, m) => 
                {
                    e.AtribuirMedico(m);
                    return e;
                }, new { UEspecialidades = especialidade });

            return result;
        }
    }
}
