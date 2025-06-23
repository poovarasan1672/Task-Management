using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Common.DTOs
{
    public class TaskFilterRequestDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 30;

        public int? UserId { get; set; }
        public int? ProjectId { get; set; }
        public string? Status { get; set; } // "completed", "pending", "overdue"
        public string? Keyword { get; set; }
    }
}
