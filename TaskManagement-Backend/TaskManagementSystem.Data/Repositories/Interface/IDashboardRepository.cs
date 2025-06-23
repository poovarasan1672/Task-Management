using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Data.Repositories.Interface
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalTasksAsync();
        Task<int> GetCompletedTasksAsync();
        Task<int> GetOverdueTasksAsync();
    }
}
