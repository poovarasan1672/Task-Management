using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Data.Model
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign Key
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
