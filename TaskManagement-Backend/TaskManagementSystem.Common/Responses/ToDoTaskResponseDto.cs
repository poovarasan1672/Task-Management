using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Common.Responses
{
    public class ToDoTaskResponseDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
