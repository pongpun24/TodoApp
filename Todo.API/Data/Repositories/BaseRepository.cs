using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Todo.API.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly TodoContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TodoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);
            if (obj != null)
                _context.Set<T>().Remove(obj);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition, Expression<Func<T, object>>[] properties)
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}