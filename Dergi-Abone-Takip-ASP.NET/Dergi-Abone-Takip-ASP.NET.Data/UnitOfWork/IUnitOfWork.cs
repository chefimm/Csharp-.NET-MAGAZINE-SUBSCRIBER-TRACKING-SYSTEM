using Dergi_Abone_Takip_ASP.NET.Data.Repositories;
using System;

namespace Dergi_Abone_Takip_ASP.NET.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
