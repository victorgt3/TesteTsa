using Demo.Dal.Context;
using Demo.Domain.Entitie.Especialidade.Repository;
using System;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Demo.Dal.Repository
{
    public class EspecialidadeRepository : Repository<Domain.Entitie.Especialidade.Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(BrtContext context) : base(context)
        {
        }

        public override Domain.Entitie.Especialidade.Especialidade ObterPorId(Guid id)
        {
            const string sql = " select * from Especialidades where id = @uId ";

            return Db.Database.GetDbConnection().Query<Domain.Entitie.Especialidade.Especialidade>(sql, new { uId = id }).FirstOrDefault();
        }

        public override IEnumerable<Domain.Entitie.Especialidade.Especialidade> ObterTodos()
        {
            const string sql = " select * from Especialidades ";

            return Db.Database.GetDbConnection().Query<Domain.Entitie.Especialidade.Especialidade>(sql);
        }
    }
}


