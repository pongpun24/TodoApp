using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(TodoContext context) : base(context)
        {
        }
    }
}