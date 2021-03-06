﻿using System;
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
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual int Add(TEntity entity)
        {
            this._unitOfWork.RoleContext.Set<TEntity>().Attach(entity);
            this._unitOfWork.RoleContext.Entry(entity).State = EntityState.Added;
            return entity.Id;
        }

        public virtual void Delete(int id)
        {
            var entity = new TEntity { Id = id };
            Delete(entity);
        }

        public virtual IQueryable<TEntity> All()
        {
            return this._unitOfWork.RoleContext.Set<TEntity>().AsNoTracking();
        }

        public virtual void Delete(TEntity entity)
        {
            this._unitOfWork.RoleContext.Set<TEntity>().Attach(entity);
            this._unitOfWork.RoleContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual IQueryable<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return this._unitOfWork.RoleContext.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        public virtual TEntity Find(int id)
        {
            return _unitOfWork.RoleContext.Set<TEntity>().AsNoTracking().FirstOrDefault(m => m.Id==id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this._unitOfWork.RoleContext.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> Page(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageIndex, Expression<Func<TEntity, Type>> orderByLamda, bool isAsc)
        {
            if (isAsc)
                return this._unitOfWork.RoleContext.Set<TEntity>().AsNoTracking().Where(predicate).OrderBy(orderByLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            else
                return this._unitOfWork.RoleContext.Set<TEntity>().AsNoTracking().Where(predicate).OrderByDescending(orderByLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual void Update<TKey>(TEntity entity, params Expression<Func<TEntity, TKey>>[] columns)
        {
            this._unitOfWork.RoleContext.Set<TEntity>().Attach(entity);
            var entry=this._unitOfWork.RoleContext.Entry(entity);
            if (columns != null && columns.Any())
                foreach (var column in columns)
                {
                    entry.Property(column).IsModified = true;
                }
        }
    }
}
