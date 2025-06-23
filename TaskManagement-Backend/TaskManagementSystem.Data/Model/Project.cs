using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Data.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
    }
}
