using Dergi_Abone_Takip_ASP.NET.Data.Repositories;
using System;

namespace Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork()
        {
            _context = new Context();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        private bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposed) { _context.Dispose(); }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
