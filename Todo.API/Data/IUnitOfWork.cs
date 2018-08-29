namespace Todo.API.Data.Repositories
{
    public interface IUnitOfWork
    {
         void Commit();

         void RejectChange();
    }
}