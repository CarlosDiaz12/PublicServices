using PublicServices.DataAccess.Data;
using PublicServices.DataAccess.Interfaces;
using PublicServices.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.DataAccess.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(
            AppDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryProperty = this.GetType().GetProperties().FirstOrDefault(x => x.PropertyType.GenericTypeArguments.FirstOrDefault() == typeof(T));
            if (repositoryProperty == null) return new BaseQueryRepository<T>(this._context);
            return repositoryProperty.GetValue(this) as IRepository<T>;
        }
    }
}
