using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Data.Model;

namespace TaskManagementSystem.Data.Repositories.Interface
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsWithTasksAsync();
        Task<Project> AddAsync(Project project);
    }
}
