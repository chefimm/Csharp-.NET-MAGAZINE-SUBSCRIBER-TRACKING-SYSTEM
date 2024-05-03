﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Dergi_Abone_Takip_ASP.NET.Data.Repositories
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate); 

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void Delete(int id);
    }
}
