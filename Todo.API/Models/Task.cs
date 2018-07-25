using System;

namespace Todo.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        
        public int TodoItemId { get; set; }
        public TodoItem TodoItem { get; set; }
    }
}