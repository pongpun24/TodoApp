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
    }
}