using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relationships
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
