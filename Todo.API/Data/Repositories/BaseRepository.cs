using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Todo.API.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public TodoContext _context { get; }
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TodoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
           _dbSet.Add(entity);
           _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);
            if (obj != null)
                _context.Set<T>().Remove(obj);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition, Expression<Func<T, object>>[] properties)
        {
            /*var obj = _context.Set<T>().Where(condition).AsQueryable();
            foreach(var prop in properties)
            {
                obj.Include(prop);
            }

            return obj.AsEnumerable();*/

            var obj = _context.Set<T>();

            return obj.ToList();

        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(){
            return _context.Set<T>().AsEnumerable();
        }
    }
}