using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Common.DTOs;
using TaskManagementSystem.Data.Model;
using TaskManagementSystem.Data.Repositories.Interface;

namespace TaskManagementSystem.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> GetAllTasksAsync()
        {
            return await _context.ToDoTasks.ToListAsync();
        }
        public async Task<ToDoTask> GetByIdAsync(int id)
        {
            return await _context.ToDoTasks
                .Include(t => t.Project)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ToDoTask> AddAsync(ToDoTask task)
        {
            _context.ToDoTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<ToDoTask> UpdateAsync(ToDoTask task)
        {
            _context.ToDoTasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.ToDoTasks.FindAsync(id);
            if (task == null) return false;

            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
