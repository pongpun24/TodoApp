using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Todo.API.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TodoContext _context;
        public UnitOfWork(TodoContext context){
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RejectChange()
        {
            foreach(var entry in _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList())
            {
                switch(entry.State){
                    case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                    entry.Reload();
                    break;
                }
            }
        }
    }
}