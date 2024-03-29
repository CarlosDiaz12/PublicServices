﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "", int? take = null, int? skip = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task Insert(T entity);
    }
}
