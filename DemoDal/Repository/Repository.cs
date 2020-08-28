﻿using Demo.Dal.Context;
using Demo.Domain.Core.Models;
using Demo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Dal.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected BrtContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(BrtContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }
        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }
        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }
        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
