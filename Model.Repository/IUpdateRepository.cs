using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public interface IUpdateRepository<TEntity>
    {
        void Update<TKey>(TEntity entity,params Expression<Func<TEntity, TKey>>[] columns);
    }
}
