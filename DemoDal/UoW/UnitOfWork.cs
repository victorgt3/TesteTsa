using Demo.Dal.Context;
using Demo.Domain.Interfaces;
using System;

namespace Demo.Dal.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BrtContext _context;

        public UnitOfWork(BrtContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var t = ex.Message;
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
