using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public interface IUserRepository : IRepository<User> {}

    public interface ITodoRepository : IRepository<TodoItem> {}

    public interface ITaskRepository : IRepository<Task> {}
}