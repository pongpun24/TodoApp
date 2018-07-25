using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public class TodoRepository : BaseRepository<TodoItem>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)

        {

        }
    }
}