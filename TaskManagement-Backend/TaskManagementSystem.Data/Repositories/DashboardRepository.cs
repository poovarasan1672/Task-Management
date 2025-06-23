using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Data.Repositories
{
    public  class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalTasksAsync()
        {
            return await _context.ToDoTasks.CountAsync();
        }

        public async Task<int> GetCompletedTasksAsync()
        {
            return await _context.ToDoTasks.CountAsync(t => t.IsCompleted);
        }

        public async Task<int> GetOverdueTasksAsync()
        {
            return await _context.ToDoTasks.CountAsync(t => !t.IsCompleted && t.DueDate < DateTime.Now);
        }
    }
}
