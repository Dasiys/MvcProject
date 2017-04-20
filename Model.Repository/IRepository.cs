using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Model.Repository
{
    public interface IRepository<TEntity> : IAddRepository<TEntity>, IDeleteRepository<TEntity>, IUpdateRepository<TEntity>, IQueryRepository<TEntity> where TEntity : IEntity
    {
    }
}
