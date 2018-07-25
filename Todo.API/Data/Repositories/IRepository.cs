using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Todo.API.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T,bool>> condition, Expression<Func<T,object>>[] properties);
    }
}