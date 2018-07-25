using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Todo.API.Models
{
    public class TodoItem
    {
        public int Id {get;set;}

        public string Subject { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public bool IsCompleted { get; set; }

        public TodoItem()
        {
            Tasks = new Collection<Task>();
        }
    }
}