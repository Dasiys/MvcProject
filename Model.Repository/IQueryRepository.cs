using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IQueryRepository<TEntity>
    {
        TEntity Find(int id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, Expression<Func<TEntity, Type>> OrderByLamda, bool isAsc);
        IQueryable<TEntity> All();
    }
}
