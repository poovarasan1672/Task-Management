using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Data.Model;

namespace TaskManagementSystem.Data.Repositories.Interface
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ToDoTask>> GetAllTasksAsync();
        Task<ToDoTask> GetByIdAsync(int id);
        Task<ToDoTask> AddAsync(ToDoTask task);
        Task<ToDoTask> UpdateAsync(ToDoTask task);
        Task<bool> DeleteAsync(int id);
    }
}
