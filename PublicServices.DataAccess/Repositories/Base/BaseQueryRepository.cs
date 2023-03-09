using Microsoft.EntityFrameworkCore;
using PublicServices.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicServices.DataAccess.Interfaces;

namespace PublicServices.DataAccess.Repositories.Base
{
    public class BaseQueryRepository<TEntity>: IRepository<TEntity> where TEntity: class 
    {
        
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseQueryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "", int? take = null, int? skip = null)
        {
            IQueryable<TEntity> result = _dbSet;

            if (filter != null)
                result = result.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                result = result.Include(includeProperty);

            if (take.HasValue && skip.HasValue)
            {
                var pageIndex = skip.Value;
                var pageSize = take.Value;
                result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            return await result.ToListAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<TEntity> result = _dbSet;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                result = result.Include(includeProperty);

            return await result.FirstOrDefaultAsync(filter);
        }
    }
}
