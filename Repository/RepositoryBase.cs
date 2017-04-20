using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Repository;

namespace Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(TEntity entity)
        {
            this._unitOfWork.RoleContext.Set<TEntity>().Attach(entity);
            this._unitOfWork.RoleContext.Entry(entity).State = EntityState.Added;
        }

        public IQueryable<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            this._unitOfWork.RoleContext.Set<TEntity>().Attach(entity);
            this._unitOfWork.RoleContext.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, Expression<Func<TEntity, Type>> OrderByLamda, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public void Update<TKey>(TEntity entity, params Expression<Func<TEntity, TKey>>[] columns)
        {
            throw new NotImplementedException();
        }
    }
}
